using UnityEngine;
using System.Collections;

public class SoundEffectPlayer : MonoBehaviour {
	AudioSource newSource;
	AudioSource priorityAudioSource;
	// Use this for initialization
	void Start () {
		newSource =  gameObject.AddComponent<AudioSource>();
		priorityAudioSource = gameObject.AddComponent<AudioSource> ();
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

	public void PlayPrioritySoundClip(AudioSource source){
		priorityAudioSource.clip = source.clip;
		priorityAudioSource.PlayOneShot (priorityAudioSource.clip);

	}
}
