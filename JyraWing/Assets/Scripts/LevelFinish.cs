using UnityEngine;
using System.Collections;

public class LevelFinish : MonoBehaviour {

	// Use this for initialization
	void OnBecameVisible(){
		//Once this become visible the level ends.
		GameObject obj = GameObject.Find ("GameController");
		if (obj) {
			GameController controller = obj.GetComponent<GameControllerBehaviour>().GetGameController();
			controller.FinishLevel(2.5f);
		}
	}
}
