#define ASSERTHIGHSCOREDATA

using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Assertions;


[System.Serializable]
public class HighScoreData {

    public SavedScoreArray scoreArray;
    private static HighScoreData instance;
	private HighScoreData() {}

    [System.Serializable]
    public struct SavedScore {
        public SavedScore(int score, string name) {
            this.score = score;
            this.name = name;
        }
        public int score;
        public string name;
    }

    [System.Serializable]
    public struct SavedScoreArray {
        public SavedScore[] scores;
    }

	public static HighScoreData Instance {
		get{
			if (instance == null) {
				instance = new HighScoreData ();
                instance.LoadGame();
			}
			return instance;
		}
	}

    public void LoadGame() {
        Debug.Log ("Loading high scores...");
        if (!File.Exists (Application.dataPath + "/highscoredata.json")) {
            InitDefaults();
			SaveGame ();
		}
        FileStream saveFile = File.Open (Application.dataPath + "/highscoredata.json", System.IO.FileMode.Open);
		StreamReader reader = new StreamReader (saveFile);
		instance = JsonUtility.FromJson<HighScoreData> (reader.ReadToEnd ());
        saveFile.Close();
    }

    public void SaveGame() {
        Debug.Log ("Saving high scores...");
		string jsonString = JsonUtility.ToJson (this);
        using (StreamWriter outputFile = new StreamWriter(Application.dataPath + "/highscoredata.json")) {
            outputFile.Flush();
            outputFile.Write(jsonString);
        }
    }

    private void InitDefaults() {
        scoreArray.scores = new SavedScore[10];
        scoreArray.scores[0] = new SavedScore(1000, "JYRAWING");
        scoreArray.scores[1] = new SavedScore(900, "JYRA");
        scoreArray.scores[2] = new SavedScore(800, "WING");
        scoreArray.scores[3] = new SavedScore(700, "PLAYER");
        scoreArray.scores[4] = new SavedScore(600, "AAA");
        scoreArray.scores[5] = new SavedScore(500, "BBB");
        scoreArray.scores[6] = new SavedScore(400, "CCC");
        scoreArray.scores[7] = new SavedScore(300, "DDD");
        scoreArray.scores[8] = new SavedScore(200, "EEE");
        scoreArray.scores[9] = new SavedScore(100, "FFF");
    }

    /// <summary>
    /// Check which high score if any the entered score is higher than
    /// </summary>
    /// <param name="score">The candidate high score</param>
    /// <returns>The highest score the current one beats. -1 if none of them</returns>
    public int CheckScore(int score) {
        //Check if this is even higher than the lowest
        if(score > scoreArray.scores[9].score) {
            //There is a score to set
            ScoreController.SetHighScoreToEnter(true, score);

            //binary search from there
            return binSearchScore(0, 9, score) + 1;
        }

        return -1;
    }

    public void EnterScore(int score, string name) {
        if(LevelControllerBehavior.SingleLevel) {
            Debug.LogError("<color=#000080ff>HighScoreData.EnterScore called but this is a single "+
                 "level being played so no highscore will save</color>");
            return;
        }

        //Get what score this replaces
        int replacementScore = CheckScore(score) - 1;
        if(replacementScore == -2) {
#if ASSERTHIGHSCOREDATA
            Debug.LogError("<color=#000080ff>HighScoreData.EnterScore called. New score of " + score + 
                " is smaller than smallest high score of "+ scoreArray.scores[9].score +"</color>");
#endif
            return;
        }
#if ASSERTHIGHSCOREDATA
        else {
            Debug.LogError("<color=#000080ff>HighScoreData.EnterScore called. New score of " + score +
                " is larger than score number " + replacementScore + " which is " +
                scoreArray.scores[replacementScore].score + "</color>");
        }
#endif
        //for this score and every score lower shift down one
        int currentShift = 9;
        while(currentShift != replacementScore) {
            scoreArray.scores[currentShift] = scoreArray.scores[currentShift-1];
            currentShift--;
        }
        scoreArray.scores[replacementScore] = new SavedScore(score, name);
    }

    public void EnterScore(SavedScore newScore) {
        EnterScore(newScore.score, newScore.name);
    }

    private int binSearchScore(int low, int high, int score) {
#if ASSERTHIGHSCOREDATA
        Assert.IsTrue(low >= 0); 
        Assert.IsTrue(high <= 9);
#endif
        int middle = (low + high) / 2;
        //Current search is higher than the score we are searching, we must go down the list
        if(scoreArray.scores[middle].score > score) {
            return binSearchScore(middle+1, high, score);
        }
        //Current search is lower than the score we are searching
        else if (scoreArray.scores[middle].score <= score) {
            //If this is the highest score or the score directly higher than the current we have found the highest
            //place for the current score
            if(middle == 0 ||
                (middle >0 &&
                scoreArray.scores[middle-1].score > score)) {
                return middle;
            //Otherwise we can go higher so bin search again
            } else {
                return binSearchScore(low, middle-1, score);
            }

        }
        return -1;
    }

    public SavedScore GetScore(int selectedScore) {
        int scoreIndex = selectedScore;
        scoreIndex--;
#if ASSERTHIGHSCOREDATA
        Assert.IsTrue(scoreIndex >= 0);
        Assert.IsTrue(scoreIndex <= 9);
#endif
        SavedScore returnScore = scoreArray.scores[scoreIndex];
        return returnScore;
    }

    public void LoadAlternateScores(SavedScore[] alternateScoreSet) {
#if ASSERTHIGHSCOREDATA
        Assert.AreEqual<int>(alternateScoreSet.Length, 10);
#endif
        scoreArray.scores = alternateScoreSet;
    }

}


