using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	private bool isHit;
	private Animator animator;

	// Use this for initialization
	void Start () {
		isHit = false;
		animator = gameObject.GetComponent <Animator> ();
		PlayerInputController.UpDownEvent += UpdateUpDownAnimation;
		Player.HitEvent += HitAnimation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateUpDownAnimation(float value) {
		if (value == 0) {
			ResetTriggers ();
			if (animator.GetInteger ("animState") == 4) {
				animator.ResetTrigger ("NeutralToUpToUp");
				animator.SetTrigger ("UpToUpToNeutral");
			} else if (animator.GetInteger ("animState") == 3) {
				animator.ResetTrigger ("NeutralToDownToDown");
				animator.SetTrigger ("DownToDownToNeutral");
			} else {
				animator.SetInteger ("animState", 0);
			}
		} else if (value ==  -1) {
			if (animator.GetInteger ("animState") == 4) {
				//animator.SetInteger ("animState", 0);
				ResetTriggers ();
			}
			animator.SetInteger ("animState", 3);
		} else if (value == 1) {
			if (animator.GetInteger ("animState") == 3) {
				//animator.SetInteger ("animState", 0);
				ResetTriggers ();
			}
			animator.SetInteger ("animState", 4);
		}
	}

	public void TransitionToUp() {
		ResetTriggers ();
		animator.SetTrigger ("NeutralToUpToUp");
	}

	public void TransitionToDown() {
		ResetTriggers ();
		animator.SetTrigger ("NeutralToDownToDown");
	}

	public void TransitionToNeutral() {
		animator.SetInteger ("animState", 0);
		ResetTriggers ();
	}

	private void ResetTriggers() {
		animator.ResetTrigger ("UpToUpToNeutral");
		animator.ResetTrigger ("DownToDownToNeutral");
		animator.ResetTrigger ("NeutralToUpToUp");
		animator.ResetTrigger ("NeutralToDownToDown");
	}

	private void HitAnimation(Player.TakingDamage takingDamage) {
		Debug.Log ("Play hit animation");
		animator.SetInteger ("animState", 1);
		isHit = true;
	}
}
