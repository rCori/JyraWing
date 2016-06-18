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
			}
			animator.SetInteger ("animState", 0);
		} else if (value ==  -1) {
			if (animator.GetInteger ("animState") == 4) {
				animator.SetInteger ("animState", 0);
				ResetTriggers ();
			}
			animator.SetInteger ("animState", 3);
		} else if (value == 1) {
			if (animator.GetInteger ("animState") == 3) {
				animator.SetInteger ("animState", 0);
				ResetTriggers ();
			}
			animator.SetInteger ("animState", 4);
		}
	}

	public void TransitionToUp() {
		ResetTriggers ();
		animator.SetTrigger ("NeutralToUpToUp");
		animator.ResetTrigger ("UpToUpToNeutral");
		animator.ResetTrigger ("DownToDownToNeutral");
		animator.ResetTrigger ("NeutralToDownToDown");
	}

	public void TransitionToDown() {
		animator.SetTrigger ("NeutralToDownToDown");
		animator.ResetTrigger ("UpToUpToNeutral");
		animator.ResetTrigger ("DownToDownToNeutral");
		animator.ResetTrigger ("NeutralToUpToUp");
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
}
