using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour 
{
	public int pointstoadd;
	public int EnemyMaxHealth;
	public int EnemyCurrentHealth;
	public int RandomDrop;

	public bool drops;
	public GameObject drop;
	public GameObject drop2;

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

			RandomDrop = Random.Range (1, 4);

			if (RandomDrop == 1) {
				Instantiate (drop, transform.position, transform.rotation);
			} 

			else if(RandomDrop == 2)
			{
				Instantiate (drop2, transform.position, transform.rotation);
			}
				
			Debug.Log ("RAND: " + RandomDrop);

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
