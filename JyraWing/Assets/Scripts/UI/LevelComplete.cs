using UnityEngine;
using System.Collections;

public class LevelComplete : MonoBehaviour {
 


	void OnBecameVisible()
	{
		GameObject obj = GameObject.Find ("GameController");
		//The boss object could be destoryed on account of the level ending.
		//If that happens this object could be null so we check for that.
		if (obj) {
			GameController controller = obj.GetComponent<GameController> ();
			controller.LevelFinished ();
		}
		Destroy (this.gameObject);
	}
}
