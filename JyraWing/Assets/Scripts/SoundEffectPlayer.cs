using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SoundEffectPlayer : MonoBehaviour {

	public int POOL_SIZE = 10;
	private int currentPoolSize;
	List<AudioSource> audioSourcePool;

	AudioSource newSource;
	AudioSource priorityAudioSource;
	// Use this for initialization
	void Start () {
		currentPoolSize = POOL_SIZE;
		newSource =  gameObject.AddComponent<AudioSource>();
		priorityAudioSource = gameObject.AddComponent<AudioSource> ();
		audioSourcePool = new List<AudioSource> ();
		for (int i = 0; i < POOL_SIZE; i++) {
			audioSourcePool.Add (gameObject.AddComponent<AudioSource> ());
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Plays the sound clip independant of other game objects.
	/// </summary>
	/// <param name="source">Source.</param>
	public void PlaySoundClip(AudioSource source){
//		newSource.clip = source.clip;
//		newSource.PlayOneShot (newSource.clip);
		for (int i = 0; i < currentPoolSize; i++) {
			if (!audioSourcePool [i].isPlaying) {
				audioSourcePool [i].clip = source.clip;
				audioSourcePool[i].PlayOneShot (audioSourcePool[i].clip);
				return;
			}
		}
		addToAudioSourcePool ();
		PlaySoundClip (source);
	}

	public void PlayClip(AudioClip clip){
		for (int i = 0; i < currentPoolSize; i++) {
			if (!audioSourcePool [i].isPlaying) {
				audioSourcePool [i].clip = clip;
				audioSourcePool [i].PlayOneShot (audioSourcePool [i].clip);
				return;
			}
		}
		addToAudioSourcePool ();
		PlayClip (clip);
	}

	private void addToAudioSourcePool(){
		audioSourcePool.Add (gameObject.AddComponent<AudioSource> ());
		currentPoolSize++;
	}
}
