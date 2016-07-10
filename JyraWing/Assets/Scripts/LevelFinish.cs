using UnityEngine;
using System.Collections;

public class LevelFinish : MonoBehaviour {

	public GameObject GameController;

	void Update(){
		if (transform.position.x <= BarrierWall.RIGHT_X) {
			GameController controller = GameController.GetComponent<GameControllerBehaviour>().GetGameController();
			controller.FinishLevel(2.5f);
			Destroy (gameObject);
		}
	}
}
