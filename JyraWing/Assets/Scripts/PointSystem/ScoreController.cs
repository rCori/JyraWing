//#define SCORECONTROLLERDEBUG

using UnityEngine;
using System.Collections;

public class ScoreController {

	public delegate void ScoreEvent (int value);

	public static event ScoreEvent AddToScoreEvent;

	private static int CurrentScore = 0;
    private static bool HasScoreToEnter = false;
    private static int HighScoreValueToEnter = 0;

	public ScoreController() {
		CountdownTimer.PlayerContinueEvent += ResetScore;
	}

	public static void AddToScore(int addition) {
		CurrentScore += addition;
		if (AddToScoreEvent != null) {
			AddToScoreEvent (CurrentScore);
		}
	}

	public static int GetScore() {
		return CurrentScore;
	}

	public static void ResetScore() {
#if SCORECONTROLLERDEBUG
        Debug.LogError("<color=#ff0000ff>Resetting current highscore</color>");
#endif
        CurrentScore = 0;
		if (AddToScoreEvent != null) {
			AddToScoreEvent (CurrentScore);
		}
	}

    public static bool GetHasScoreToEnter() {
        return HasScoreToEnter;
    }

    public static int GetHighScoreValueToEnter() {
        if(HasScoreToEnter) {
            return HighScoreValueToEnter;
        }
        return -1;
    }

    public static void SetHighScoreToEnter(bool hasScore, int curScore) {
        if(hasScore && HasScoreToEnter) {
            if(curScore > HighScoreValueToEnter) {
                HighScoreValueToEnter = curScore;
            }
        } else {
            HasScoreToEnter = hasScore;
            HighScoreValueToEnter = curScore;
        }

    }

    ~ScoreController() {
        CountdownTimer.PlayerContinueEvent -= ResetScore;
    }
}
