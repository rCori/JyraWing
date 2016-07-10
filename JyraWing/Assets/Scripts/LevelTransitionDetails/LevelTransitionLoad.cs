using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTransitionLoad : MonoBehaviour {

	public float timeToLoad = 5.0f;

	string nextLevel;

	// Use this for initialization
	void Start () {
		nextLevel = LevelController.NextLevel;
	}
	
	// Update is called once per frame
	void Update () {
		timeToLoad -= Time.deltaTime;
		//If time is up, load the next level
		if (timeToLoad < 0) {
			//PlayerInputController.RemoveAllEvents ();
			SceneManager.LoadScene(nextLevel);
		}
	}
}
