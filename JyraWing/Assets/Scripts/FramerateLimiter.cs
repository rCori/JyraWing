using UnityEngine;
using System.Collections;

public class FramerateLimiter : MonoBehaviour {

	public int framerateTarget = 60; 

	// Use this for initialization
	void Awake () {
		Application.targetFrameRate = framerateTarget;
		QualitySettings.vSyncCount = 0;
	}
}
