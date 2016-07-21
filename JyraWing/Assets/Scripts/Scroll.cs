using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour, PauseableItem {

	public float speed;

	//We need to safely register this item to the gameController
	//This item might get created before the gameController so this ensures safety

	private bool _paused;

	void Start() {
		_paused = false;
		RegisterToList ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!_paused) {
			transform.position -= new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}
	}
		
	void OnDestroy()
	{
		RemoveFromList ();
	}

	/* Implementation of PauseableItem interface */
	public bool paused
	{
		get
		{
			return _paused;
		}
		
		set
		{
			_paused = value;
		}
	}
	
	public void RegisterToList()
	{
		if (GameObject.Find ("PauseController")) {
			//GameObject.Find ("GameController").GetComponent<GameControllerBehaviour>().GetGameController().RegisterPauseableItem(this);
			GameObject.Find ("PauseController").GetComponent<PauseControllerBehavior>().RegisterPauseableItem(this);
		}
	}

	//We can remove from the list without checking, it will be safe.
	public void RemoveFromList()
	{
		if (GameObject.Find ("PauseController")) {
			GameObject.Find ("PauseController").GetComponent<PauseControllerBehavior>().DelistPauseableItem(this);
		}
	}
}
