using UnityEngine;
using System.Collections;

public class PlayerShieldBehaviour : MonoBehaviour {

	private IPlayerShield playerShield;
	//public OldPlayerInputController playerInputController;

	private Animator animator;

	/// <summary>
	/// GameController used to update UI.
	/// </summary>
	public GameController gameController;

	// Use this for initialization
	void Awake () {
		//Set the PlayerShield interface to the one implementation it has
		SetPlayerShield (new PlayerShield());
		//We will need player input for the player shield to update correctly.
		//playerInputController = new OldPlayerInputController ();
		//Set the gameobjects animator
		animator = gameObject.GetComponent<Animator> ();
		PlayerInputController.ShieldButton += OnShieldButton;
	}
	
	// Update is called once per frame
	void Update () {
		//Can't set gameController on awake
		if (gameController == null) {
			gameController = GameObject.Find ("GameController").GetComponent<GameControllerBehaviour> ().GetGameController ();
		}
		//Only poll these values once per Update for consistency
		//bool ShieldButton = playerInputController.GetShieldButton ();
		//Update the status of the shieldplayerShield.GetShieldPercentage ()
		playerShield.UpdateShield (Time.deltaTime);
		float ShieldPercentage = playerShield.GetShieldPercentage ();
		//Update the ui that shows the player shield left
		if (gameController != null) {
			gameController.ShieldPercentage = (int)ShieldPercentage;
		}
		//update the position of the GameObject
		gameObject.transform.position = playerShield.spritePosition;
		//Later we will do some other stuff with animation state and such of the actual gameobject
		//Poll this value after the update to shield has happened
		bool HasShield = playerShield.HasShield ();
		UpdateShieldAppearance (HasShield);
	}

	public IPlayerShield GetPlayerShield(){
		return playerShield;
	}

	public void SetPlayerShield(IPlayerShield newPlayerShield){
		playerShield = newPlayerShield;
	}

	private void UpdateShieldAppearance(bool hasShield){
		//If the shield is active
		if (hasShield) {
			animator.SetInteger ("animState", 0);
		//Shield is inactive
		} else {
			animator.SetInteger ("animState", 3);
		}

	}

	/// <summary>
	/// Event for the shield button
	/// </summary>
	public void OnShieldButton(bool down) {
		if (down) {
			playerShield.ActivateShield ();
		} else {
			playerShield.DeactivateShield ();
		}
	}

	void OnDestroy() {
		PlayerInputController.ShieldButton -= OnShieldButton;
	}

}
