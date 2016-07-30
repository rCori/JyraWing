using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	private bool isHit;
	private bool animStuck;
	private Animator animator;

	// Use this for initialization
	void Start () {
		isHit = false;
		animStuck = false;
		animator = gameObject.GetComponent <Animator> ();
		PlayerInputController.UpDownEvent += UpdateUpDownAnimation;
		Player.HitEvent += HitAnimation;
		CountdownTimer.PlayerContinueEvent += ResetHitAnimation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateUpDownAnimation(float value) {
		if (!isHit) {
			if (value == 0) {
				if (animator.GetInteger ("animState") == 4) {
					animator.SetInteger ("animState", 0);
				} else if (animator.GetInteger ("animState") == 3) {
					animator.SetInteger ("animState", 0);
				} else if (animator.GetInteger ("animState") == 7) {
					if (animator.GetCurrentAnimatorStateInfo (0).IsName ("playerNeutralToUp")) {
						animator.SetInteger ("animState", 0);
					} else {
						animator.SetInteger ("animState", 8);
					}
				} else if (animator.GetInteger ("animState") == 9) {
					if (animator.GetCurrentAnimatorStateInfo (0).IsName ("playerNeutralToDown")) {
						animator.SetInteger ("animState", 0);
					} else {
						animator.SetInteger ("animState", 10);
					}
				}
			} else if (value == -1) {
				animator.SetInteger ("animState", 3);
			} else if (value == 1) {
				animator.SetInteger ("animState", 4);
			}
		} else {
			if (!animStuck) {
				if (value == 0) {
					animator.SetInteger ("animState", 2);
				} else if (value == -1) {
					animator.SetInteger ("animState", 5);
				} else if (value == 1) {
					animator.SetInteger ("animState", 6);
				}
			}
		}
	}

	public void TransitionToUp() {
		animator.SetInteger ("animState", 7);
	}

	public void TransitionToDown() {
		animator.SetInteger ("animState", 9);
	}

	public void TransitionToNeutral() {
		animator.SetInteger ("animState", 0);
	}
		

	private void HitAnimation(Player.TakingDamage takingDamage) {
		switch(takingDamage) {
		case Player.TakingDamage.EXPLODE:
			animator.SetInteger ("animState", 1);
			isHit = true;
			animStuck = true;
			break;
		case Player.TakingDamage.RETURNING:
			animator.SetInteger ("animState", 2);
			animStuck = false;
			break;
		case Player.TakingDamage.BLINKING:
			Debug.Log ("Setting animState = 2");
			animator.SetInteger ("animState", 2);
			break;
		case Player.TakingDamage.NONE:
			animator.SetInteger ("animState", 0);
			isHit = false;
			break;
		default:
			break;
		}
	}

	public void ResetHitAnimation() {
		isHit = true;
		animator.SetTrigger("blinkTrigger");
		animator.SetInteger ("animState", 2);
		Debug.Log ("ResetHitAnimation");
	}

	void OnDestroy() {
		PlayerInputController.UpDownEvent -= UpdateUpDownAnimation;
		Player.HitEvent -= HitAnimation;
		CountdownTimer.PlayerContinueEvent -= ResetHitAnimation;
	}
}
