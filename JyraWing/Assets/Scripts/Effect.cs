using UnityEngine;
using System.Collections;

public class Effect : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	Animator animator;
	bool active;

	void Awake() {
		active = false;
		animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	public void Reset() {
		animator.SetTrigger("StopAnim");
		transform.localPosition = Vector2.zero;
		active = false;
	}

	public void Play(Vector2 pos) {
		if (!animator) {
			animator = GetComponent<Animator> ();
		}
		transform.localPosition = pos;
		animator.SetTrigger("StartAnim");
		active = true;
	}

	public bool IsActive() {
		return active;
	}
}
