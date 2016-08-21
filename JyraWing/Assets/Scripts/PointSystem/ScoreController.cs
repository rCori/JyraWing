using UnityEngine;
using System.Collections;

public class ScoreController {

	public delegate void ScoreEvent (int value);

	public static event ScoreEvent AddToScoreEvent;

	private static int CurrentScore = 0;

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
		CurrentScore = 0;
		AddToScoreEvent (CurrentScore);
	}
}
