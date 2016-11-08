using UnityEngine;
using System.Collections;

public class PauseControllerBehavior : MonoBehaviour {

	IPauseController pauseController;

	public delegate void PauseDelegate();
	public static event PauseDelegate PauseEvent;

    private static bool paused;

	// Use this for initialization
	void Awake () {
		pauseController = new PauseController ();
		PlayerInputController.StartButton += PauseBehavior;
        OnScreenDialog.PauseOnScreenDialogStartEvent += () => ShowingDialog();
		IngameMenu.UnpauseEvent += () => { pauseController.Unpause(); paused = false; Time.timeScale = 1;};
        OnScreenDialog.PauseOnScreenDialogEndEvent += () => { pauseController.Unpause(); paused = false; Time.timeScale = 1;};
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
                    paused = true;
                    Time.timeScale = 0;
					PauseEvent ();
				}
			}
		}
	}

    public void ShowingDialog() {
        pauseController.PauseAllItems ();
		if (PauseEvent != null) {
            paused = true;
            Time.timeScale = 0;
			//PauseEvent ();
		}
    }

	void OnDestroy() {
		pauseController.Purge ();
		PlayerInputController.StartButton -= PauseBehavior;
        IngameMenu.UnpauseEvent -= () => { pauseController.Unpause();  paused = false; Time.timeScale = 1; };

        OnScreenDialog.PauseOnScreenDialogStartEvent -= () => pauseController.PauseAllItems ();
        OnScreenDialog.PauseOnScreenDialogEndEvent -= () => pauseController.Unpause();
	}

    public static IEnumerator WaitForPauseSeconds(float time) {
        float start = Time.time;
        while(Time.time < start+ time) {
            yield return null;
        }
    }

    public static IEnumerator WaitForRealSeconds(float time) {
        float start = Time.realtimeSinceStartup;
        while(Time.realtimeSinceStartup < start+ time) {
            yield return null;
        }
    }

}
