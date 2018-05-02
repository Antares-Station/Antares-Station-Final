using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour 
{
	public GameObject PauseBackground;



	private bool paused = false;

	void Start()
	{
		PauseBackground.SetActive (false);
	}

	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Pause")) 
		{
			if (paused) 
			{
				Resume ();
			} else 
			{
				Pause ();
			}
		} 

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (paused) 
			{
				Resume ();
			} else 
			{
				Pause ();
			}
		} 
			


	}

	public void Resume()
	{
		PauseBackground.SetActive (false);

		Time.timeScale = 1;
		paused = false;
	}

	void Pause()
	{
		PauseBackground.SetActive (true);
	
		Time.timeScale = 0;
		paused = true;
	}

}
