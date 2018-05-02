using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour 
{

	public int damageToGive;


	void OnCollisionEnter2D(Collision2D other)
	{
		 if(other.gameObject.tag == "Enemy") 
		{
			other.gameObject.GetComponent<EnemyHealthManager> ().BulletDamage (damageToGive);

			other.gameObject.GetComponent<BossHealthManager> ().BulletDamage (damageToGive);

			Destroy(gameObject);
		}

	}
}