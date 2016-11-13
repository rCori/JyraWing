using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SoundEffectPlayer : MonoBehaviour {

	public int POOL_SIZE = 10;
	private int currentPoolSize;
	List<AudioSource> audioSourcePool;

    float currentSFXVolume;

	// Use this for initialization
	void Start () {
		currentPoolSize = POOL_SIZE;
        currentSFXVolume = SaveData.Instance.SFXLevel;
		audioSourcePool = new List<AudioSource> ();
		for (int i = 0; i < POOL_SIZE; i++) {
            AudioSource newPoolAudioSource = gameObject.AddComponent<AudioSource>();
            newPoolAudioSource.volume = currentSFXVolume;
			audioSourcePool.Add (newPoolAudioSource);
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
        AudioSource newPoolAudioSource = gameObject.AddComponent<AudioSource>();
        newPoolAudioSource.volume = currentSFXVolume;
		audioSourcePool.Add (newPoolAudioSource);
		currentPoolSize++;
	}

    public void SetVolume(int volumeLevel) {
        float floatVolume = volumeLevel;
        floatVolume /= 10f;
        currentSFXVolume = floatVolume;
        if (audioSourcePool == null) return;
        foreach(AudioSource source in audioSourcePool) {
            source.volume = currentSFXVolume;
        }
    }
}
