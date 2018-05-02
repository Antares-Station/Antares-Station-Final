using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour 
{

	public Slider Volume;
	public AudioSource audioClip;
	// Use this for initialization
	void Update () 
	{
		audioClip.volume = Volume.value;
	}
	

}
