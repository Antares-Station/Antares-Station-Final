using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playMenu : MonoBehaviour 
{

	public void Play(string sceneName)
	{

        SceneManager.LoadScene(sceneName: "Main Menu");

    }

}
