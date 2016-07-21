using UnityEngine;
using System.Collections;

public class AwardPoints : MonoBehaviour {

	public int PointValue = 0;
	private AudioClip audioClip;
	private SoundEffectPlayer soundEffectPlayer;

	// Use this for initialization
	void Start () {
		soundEffectPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer> ();
		audioClip = Resources.Load ("Audio/SFX/pointPickup") as AudioClip;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			ScoreController.AddToScore (PointValue);
			if (soundEffectPlayer && audioClip) {
				soundEffectPlayer.PlayClip (audioClip);
			}
			Destroy (gameObject);
		}
	}
}
