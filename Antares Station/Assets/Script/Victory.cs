using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour 
{

	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("Enter Collider");
		SceneManager.LoadScene ("Credits");
	}


}
