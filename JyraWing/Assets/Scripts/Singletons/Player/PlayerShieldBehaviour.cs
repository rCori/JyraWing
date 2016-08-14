using UnityEngine;
using System.Collections;

public class PlayerShieldBehaviour : MonoBehaviour, PauseableItem {

	private IPlayerShield playerShield;
	//public OldPlayerInputController playerInputController;

	private Animator animator;

	/// <summary>
	/// GameController used to update UI.
	/// </summary>
	public GameController gameController;

	private bool _paused;

	// Use this for initialization
	void Awake () {
		//Set the PlayerShield interface to the one implementation it has
		SetPlayerShield (new PlayerShield());
		//We will need player input for the player shield to update correctly.
		//playerInputController = new OldPlayerInputController ();
		//Set the gameobjects animator
		animator = gameObject.GetComponent<Animator> ();
		PlayerInputController.ShieldButton += OnShieldButton;
		RegisterToList ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_paused) {
			return;
		}
		//Can't set gameController on awake
		if (gameController == null) {
			gameController = GameObject.Find ("GameController").GetComponent<GameControllerBehaviour> ().GetGameController ();
		}
		//Only poll these values once per Update for consistency
		//bool ShieldButton = playerInputController.GetShieldButton ();
		//Update the status of the shieldplayerShield.GetShieldPercentage ()
		playerShield.UpdateShield (Time.deltaTime);
		//update the position of the GameObject
		gameObject.transform.position = playerShield.spritePosition;
		//Later we will do some other stuff with animation state and such of the actual gameobject
		//Poll this value after the update to shield has happened
		bool HasShield = playerShield.HasShield ();
		bool ShieldEnabled = playerShield.shieldEnabled;
		UpdateShieldAppearance (HasShield, ShieldEnabled);
	}

	public IPlayerShield GetPlayerShield(){
		return playerShield;
	}

	public void SetPlayerShield(IPlayerShield newPlayerShield){
		playerShield = newPlayerShield;
	}

	private void UpdateShieldAppearance(bool hasShield, bool shieldEnabled){
		//If the shield is not enabled, that animation takes prescedence
		if (!shieldEnabled) {
			animator.SetInteger ("animState", 2);
			return;
		}
		//If the shield is active
		if (hasShield) {
			animator.SetInteger ("animState", 0);
		//Shield is inactive
		} else {
			animator.SetInteger ("animState", 1);
		}

	}

	/// <summary>
	/// Event for the shield button
	/// </summary>
	public void OnShieldButton(bool down) {
		if (_paused) {
			return;
		}
		if (down) {
			playerShield.ActivateShield ();
		} else {
			playerShield.DeactivateShield ();
		}
	}

	void OnDestroy() {
		PlayerInputController.ShieldButton -= OnShieldButton;
		RemoveFromList ();
	}


	/* Implementation of PauseableItem interface */
	public bool paused
	{
		get
		{
			return _paused;
		}

		set{
			_paused = value;
			if(_paused){
				animator.speed = 0f;
				playerShield.DeactivateShield ();
				PlayerInputController.ShieldButton -= OnShieldButton;
			}
			else{
				animator.speed = 1f;
				PlayerInputController.ShieldButton += OnShieldButton;
			}
		}
	}

	public void RegisterToList()
	{
		if (GameObject.Find ("PauseController")) {
			GameObject.Find ("PauseController").GetComponent<PauseControllerBehavior>().RegisterPauseableItem(this);
		}
	}

	public void RemoveFromList()
	{
		if (GameObject.Find ("PauseController")) {
			GameObject.Find ("PauseController").GetComponent<PauseControllerBehavior>().DelistPauseableItem(this);
		}
	}

}
