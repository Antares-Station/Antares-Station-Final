using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour 
{
	public GameObject PlayerBulletGO;
	private int bulletcounter = 1;
	public float Timer;
	public float maxTime = 2f;
	public EnemyState enemyState;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{


		switch (enemyState) 
		{
		case EnemyState.Ready:
			if (bulletcounter == 1) {
				//spawn down
				GameObject enemyBullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);
				enemyBullet01.GetComponent<EnemyBullet> ().yspeed = -10.0f;
				bulletcounter++;
				enemyState = EnemyState.Coolup;
				break;
			} else if (bulletcounter == 2) {
				//Spawn downRight
				GameObject enemyBullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);
				enemyBullet01.GetComponent<EnemyBullet> ().xspeed = 10.0f;
				enemyBullet01.GetComponent<EnemyBullet> ().yspeed = -10.0f;
				bulletcounter++;
				enemyState = EnemyState.Coolup;
				break;
			} else if (bulletcounter == 3) {
				//Spawn Right
				GameObject enemyBullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);
				enemyBullet01.GetComponent<EnemyBullet> ().xspeed = 10.0f;
				bulletcounter++;
				enemyState = EnemyState.Coolup;
				break;
			} else if (bulletcounter == 4) {
				//Spawn UpRight
				GameObject enemyBullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);
				enemyBullet01.GetComponent<EnemyBullet> ().xspeed = 10.0f;
				enemyBullet01.GetComponent<EnemyBullet> ().yspeed = 10.0f;
				bulletcounter++;
				enemyState = EnemyState.Coolup;
				break;
			} else if (bulletcounter == 5) {
				//Spawn Up
				GameObject enemyBullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);
				enemyBullet01.GetComponent<EnemyBullet> ().yspeed = 10.0f;
				bulletcounter++;
				enemyState = EnemyState.Coolup;
				break;
			} else if (bulletcounter == 6) {
				//Spawn UpLeft
				GameObject enemyBullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);
				enemyBullet01.GetComponent<EnemyBullet> ().xspeed = -10.0f;
				enemyBullet01.GetComponent<EnemyBullet> ().yspeed = 10.0f;
				bulletcounter++;
				enemyState = EnemyState.Coolup;
				break;
			} else if (bulletcounter == 7) {
				//Spawn Left
				GameObject enemyBullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);
				enemyBullet01.GetComponent<EnemyBullet> ().xspeed = -10.0f;
				bulletcounter++;
				enemyState = EnemyState.Coolup;
				break;
			} else if (bulletcounter == 8) {
				//Spawn DownLeft
				GameObject enemyBullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);
				enemyBullet01.GetComponent<EnemyBullet> ().xspeed = -10.0f;
				enemyBullet01.GetComponent<EnemyBullet> ().yspeed = -10.0f;
				bulletcounter = 1;
				enemyState = EnemyState.Coolup;
				break;
			}

			break;
		case EnemyState.Coolup:
			Debug.Log ("Start dashstate Coolup");
			Timer += Time.deltaTime * 3;
			if(Timer >= maxTime)
			{
				Timer = maxTime;
				enemyState = EnemyState.Cooldown;
			}
			break;
		case EnemyState.Cooldown:
			Debug.Log ("bulletcounter = " + bulletcounter);
			Debug.Log ("Start dashstate cooldown");
			Timer -= Time.deltaTime;
			if(Timer <= 0)
			{
				Timer = 0;
				enemyState = EnemyState.Ready;
			}
			break;
		}



	
	
	}
		
}

public enum EnemyState 
{
	Ready,
	Coolup,
	Cooldown
}
