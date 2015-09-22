using UnityEngine;
using System.Collections;

public class SoundEffectPlayer : MonoBehaviour {
	AudioSource newSource;
	// Use this for initialization
	void Start () {
		newSource =  gameObject.AddComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Plays the sound clip independant of other game objects.
	/// </summary>
	/// <param name="source">Source.</param>
	public void PlaySoundClip(AudioSource source){
		newSource.clip = source.clip;
		newSource.PlayOneShot (newSource.clip);
	}

	public void PlayClip(AudioClip clip){
		if (newSource) {
			newSource.clip = clip;
			newSource.PlayOneShot (newSource.clip);
		}
	}
}
