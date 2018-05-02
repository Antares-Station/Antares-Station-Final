using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization

	public void ToMainMenu()
	{
		SceneManager.LoadScene ("Main Menu");
	}
}
