using UnityEngine;
using System.Collections;

public class PlayerShieldBehaviour : MonoBehaviour {

	private IPlayerShield playerShield;
	public PlayerInputController playerInputController;

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
		playerInputController = new PlayerInputController ();
		//Set the gameobjects animator
		animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Only poll these values once per Update for consistency
		bool ShieldButton = playerInputController.GetShieldButton ();
		float ShieldPercentage = playerShield.GetShieldPercentage ();
		//Update the status of the shieldplayerShield.GetShieldPercentage ()
		playerShield.UpdateShield (Time.deltaTime, ShieldButton);
		//Update the ui that shows the player shield left
		gameController.UpdatePlayerShield (ShieldPercentage);
		//update the position of the GameObject
		gameObject.transform.position = playerShield.spritePosition;
		//Later we will do some other stuff with animation state and such of the actual gameobject
		//Poll this value after the update to shield has happened
		bool HasShield = playerShield.HasShield (ShieldButton);
		UpdateShieldAppearance (ShieldPercentage, HasShield);
	}

	public IPlayerShield GetPlayerShield(){
		return playerShield;
	}

	public void SetPlayerShield(IPlayerShield newPlayerShield){
		playerShield = newPlayerShield;
	}
	
	private void UpdateShieldAppearance(float shieldPercentage, bool hasShield){
		//If the shield is active
		if (hasShield) {
			if (shieldPercentage > 66.0f) {
				animator.SetInteger ("animState", 0);
			} else if (shieldPercentage < 66.0f && shieldPercentage > 33.0f) {
				animator.SetInteger ("animState", 1);
			} else if (shieldPercentage < 33.0f) {
				animator.SetInteger ("animState", 2);
			}
		//Shield is inactive
		} 
		else {
			if (shieldPercentage > 66.0f) {
				animator.SetInteger ("animState", 3);
			} else if (shieldPercentage < 66.0f && shieldPercentage > 33.0f) {
				animator.SetInteger ("animState", 4);
			} else if (shieldPercentage < 33.0f) {
				animator.SetInteger ("animState", 5);
			}
		}

	}

}
