using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealthManager : MonoBehaviour 
{
	public int pointstoadd;
	public int EnemyMaxHealth;
	public int EnemyCurrentHealth;
	public GameObject CanvasObject;

	//Sound Effects
	public AudioSource EnemyAudio;
	public AudioClip EnemyDeathSound;

	void Start () 
	{
		EnemyCurrentHealth = EnemyMaxHealth;	
	}


	void Update ()
	{

		if (EnemyCurrentHealth <= 0) 
		{
			EnemyAudio.PlayOneShot (EnemyDeathSound);

			Destroy(gameObject);

			CanvasObject.GetComponent<Canvas> ().enabled = false;

			SceneManager.LoadScene ("Credits");

			ScoreManager.AddPoints (pointstoadd);
		}

	}

	public void makeDead()
	{

	}

	public void BulletDamage(int damageToGive)
	{
		EnemyCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth()
	{
		EnemyCurrentHealth = EnemyMaxHealth;
	}
}
