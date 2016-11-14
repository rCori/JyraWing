using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class VolumeSettings : MonoBehaviour {

    public SoundEffectPlayer soundEffectPlayer;
    public AudioSource bgmAudioSource;

	// Use this for initialization
	void Start () {
        Assert.IsNotNull(soundEffectPlayer);
        Assert.IsNotNull(bgmAudioSource);
        SaveData.Instance.LoadGame();
        SetBGMAudio(SaveData.Instance.BGMLevel);
        SetSFXAudio(SaveData.Instance.SFXLevel);
	}

    public void SetBGMAudio(int audioLevel) {
        float floatAudio = audioLevel;
        floatAudio /= 10f;
        bgmAudioSource.volume = floatAudio;
    }

    public void SetSFXAudio(int audioLevel) {
        soundEffectPlayer.SetVolume(audioLevel);
    }

}
