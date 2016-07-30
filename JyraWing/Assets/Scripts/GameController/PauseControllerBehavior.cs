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
		IngameMenu.UnpauseEvent += () => pauseController.Unpause ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Set the pause controller interface for the game controller
	public void SetPauseController(IPauseController i_pauseController){
		pauseController = i_pauseController;
	}

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
			}
		}
	}

	void OnDestroy() {
		PlayerInputController.StartButton -= PauseBehavior;
		IngameMenu.UnpauseEvent -= () => pauseController.Unpause ();
	}
}
