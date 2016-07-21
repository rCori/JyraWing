using UnityEngine;
using System.Collections;

public class PauseControllerBehavior : MonoBehaviour {

	IPauseController pauseController;

	public delegate void PauseDelegate();
	public static event PauseDelegate PauseEvent;

	// Use this for initialization
	void Awake () {
		pauseController = new PauseController ();
		PlayerInputController.StartButton += PauseBehavior;
		IngameMenu.UnpauseEvent += () => PauseBehavior(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Set the pause controller interface for the game controller
	public void SetPauseController(IPauseController i_pauseController){
		pauseController = i_pauseController;
	}

//	///Allows the user to pause all items that have been registered to pause
//	public void PauseAllItems()
//	{
//		pauseController.PauseAllItems ();
//	}
//
//	///Allows the user to unpause all items that have been registered to pause and resume the game
//	public void Unpause()
//	{
//		pauseController.Unpause ();
//	}

	/// <summary>
	/// Registers and item to be globablly paused
	/// </summary>
	/// <param name="item">Item to register.</param>
	public void RegisterPauseableItem(PauseableItem item)
	{
		pauseController.RegisterPausableItem (item);
	}

	/// <summary>
	/// Remove and item from the pause list
	/// </summary>
	/// <param name="item">Item.</param>
	public void DelistPauseableItem(PauseableItem item)
	{
		pauseController.DelistPauseableItem (item);
	}

	public bool IsPaused{
		get{
			return pauseController.IsPaused;
		}
	}

	public void PauseBehavior(bool down) {
		if (down) {
			if (!pauseController.IsPaused) {
				pauseController.PauseAllItems ();
				if (PauseEvent != null) {
					PauseEvent ();
				}
			} else {
				pauseController.Unpause ();
			}
		}
	}

	void OnDestroy() {
		PlayerInputController.StartButton -= PauseBehavior;
		IngameMenu.UnpauseEvent -= () => PauseBehavior(true);
	}
}
