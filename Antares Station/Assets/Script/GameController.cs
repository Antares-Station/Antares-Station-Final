using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	private AudioMixer audioMixer;
	private Slider MasterVolume;

	float master;
	float music;

	void Awake() 
	{
		audioMixer = Resources.Load ("Audio/MasterVolume") as AudioMixer;
		MasterVolume = GameObject.Find("Music_Volume").GetComponent<Slider>();
	}

	void Start () {
		audioMixer.GetFloat ("MasterVolume", out master);
		audioMixer.GetFloat ("MasterVolume", out music);

		Debug.Log ("Master: " + master);
		Debug.Log ("Music: " + music);

		MasterVolume.value = music;


	}

	public void changeMasterVolume () {
		//audioMixer.SetFloat ("MasterVol", MasterVolume.value);
		audioMixer.SetFloat ("MusicVol", MasterVolume.value);
		// Write to PlayerPrefs if you wanted...
	}

	void Update () {
		if (Input.GetKeyUp (KeyCode.F1)) {
			audioMixer.SetFloat ("MasterVol", master -5.0f);
			audioMixer.SetFloat ("MusicVol", music-5.0f);
		}
		if (Input.GetKeyUp (KeyCode.F2)) {
			audioMixer.SetFloat ("MasterVol", master +5.0f);
			audioMixer.SetFloat ("MusicVol", music+5.0f);
		}
	}
}
