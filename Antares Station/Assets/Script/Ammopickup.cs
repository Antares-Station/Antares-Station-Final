using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammopickup : MonoBehaviour {

	public int Ammopoints;

	void OnTriggerEnter2D(Collider2D other)
	{
		playermovement PM = other.GetComponent<playermovement> ();
		Debug.Log ("A: " + other.gameObject.name);
//		if(other.gameObject.tag == "player")
		if (PM != null) {
			Debug.Log ("B");

			Debug.Log (playermovement.MoveSpeed);
			PM.AmmoAmount (Ammopoints);
			Destroy (gameObject);

		}
//		PlayerPrefs.SetInt ("Score", 5);
//		GameManager.HighScore = PlayerPrefs.GetInt ("Score");
	}
}
