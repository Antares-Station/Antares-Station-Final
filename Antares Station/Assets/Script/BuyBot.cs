using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuyBot : MonoBehaviour 
{

	public int Money;
	public int PointsToTake= 15;
	public int healthToGive = 15;
	public int ammoToGive = 15;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Money = MoneyManager.money;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
			Debug.Log ("entering collision");

			other.gameObject.GetComponent<MoneyManager> ();
			other.gameObject.GetComponent<PlayerHealthManager> ();
			other.gameObject.GetComponent<AmmoManager> ();

		if (Money > PointsToTake) 
		{
				Debug.Log ("Money = " + Money);

				if (Input.GetKeyDown("G")) 
				{
					Debug.Log ("taking points for health");

					MoneyManager.TakePointsforHealth (PointsToTake);

					PlayerHealthManager.Me.AddHealth (healthToGive);

				}

				if (Input.GetKeyDown("H")) 
				{
					MoneyManager.TakePointsforHealth (PointsToTake);

					AmmoManager.AddAmmo (ammoToGive);

				}

				if (Input.GetButtonDown ("Interact1")) 
				{
					Debug.Log ("taking points for health");

					MoneyManager.TakePointsforHealth (PointsToTake);
					
					PlayerHealthManager.Me.AddHealth (healthToGive);
					
				}
				
				if (Input.GetButtonDown ("Interact2")) 
				{
					MoneyManager.TakePointsforHealth (PointsToTake);

					AmmoManager.AddAmmo (ammoToGive);
					
				}
		}

	}

}
