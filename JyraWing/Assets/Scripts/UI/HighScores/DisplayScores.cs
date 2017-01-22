using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DisplayScores : MonoBehaviour {

    public List<Text> text;

	// Use this for initialization
	void Start () {
        LoadAllText(text);
	}
	
    void Update() {
        if(ButtonInput.Instance().FireButtonDown() || ButtonInput.Instance().StartButtonDown() || ButtonInput.Instance().ShieldButtonDown()) {
            StartCoroutine(LoadTitleScene());
        }
    }

    private void LoadAllText(List<Text> displayText) {
        displayText[0].text = HighScoreData.Instance.GetScore(1).name + ": " + HighScoreData.Instance.GetScore(1).score;
        displayText[1].text = HighScoreData.Instance.GetScore(2).name + ": " + HighScoreData.Instance.GetScore(2).score;
        displayText[2].text = HighScoreData.Instance.GetScore(3).name + ": " + HighScoreData.Instance.GetScore(3).score;
        displayText[3].text = HighScoreData.Instance.GetScore(4).name + ": " + HighScoreData.Instance.GetScore(4).score;
        displayText[4].text = HighScoreData.Instance.GetScore(5).name + ": " + HighScoreData.Instance.GetScore(5).score;
        displayText[5].text = HighScoreData.Instance.GetScore(6).name + ": " + HighScoreData.Instance.GetScore(6).score;
        displayText[6].text = HighScoreData.Instance.GetScore(7).name + ": " + HighScoreData.Instance.GetScore(7).score;
        displayText[7].text = HighScoreData.Instance.GetScore(8).name + ": " + HighScoreData.Instance.GetScore(8).score;
        displayText[8].text = HighScoreData.Instance.GetScore(9).name + ": " + HighScoreData.Instance.GetScore(9).score;
        displayText[9].text = HighScoreData.Instance.GetScore(10).name + ": " + HighScoreData.Instance.GetScore(10).score;
    }

    IEnumerator LoadTitleScene() {
        //PlayConfirm ();
		//lockScreen = true;
        yield return StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.1f));
        Time.timeScale = 1f;
        SceneManager.LoadScene("titleScene");
    }

}
