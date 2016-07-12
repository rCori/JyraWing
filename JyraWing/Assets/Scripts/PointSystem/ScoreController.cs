﻿using UnityEngine;
using System.Collections;

public class ScoreController {

	public delegate void ScoreEvent (int value);

	public static event ScoreEvent AddToScoreEvent;

	private static int CurrentScore = 0;

	public ScoreController() {
	}

	public static void AddToScore(int addition) {
		CurrentScore += addition;
		AddToScoreEvent (CurrentScore);
	}

	public static int GetScore() {
		return CurrentScore;
	}

}
