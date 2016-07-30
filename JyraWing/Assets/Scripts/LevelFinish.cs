using UnityEngine;
using System.Collections;

public class LevelFinish : MonoBehaviour {

	public GameObject GameController;
	public LevelControllerBehavior levelControllerBehavior;

	void Update(){
		if (transform.position.x <= BarrierWall.RIGHT_X) {
			GameController controller = GameController.GetComponent<GameControllerBehaviour>().GetGameController();
			levelControllerBehavior.HandleLevelFinished ();
			Destroy (gameObject);
		}
	}
}
