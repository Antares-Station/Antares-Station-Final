using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour 
{

	public int playerMaxHealth;
	public int playerCurrentHealth;
	public GameObject CanvasObject;

	//Reset Variables
	int ResetMoney = 0;
	int ResetPoints = 0;

	//Sound Effects
	public AudioSource PlayerAudio;
	public AudioClip PlayerDeathSound;

	public static PlayerHealthManager Me;


	void Start () 
	{
		PlayerHealthManager.Me = this;
		playerCurrentHealth = playerMaxHealth;	
	}
	

	void Update ()
	{
		
		if (playerCurrentHealth <= 0) 
		{

			gameObject.SetActive (false);

			CanvasObject.GetComponent<Canvas> ().enabled = false;

			SceneManager.LoadScene ("EndScreen");

			PlayerAudio.PlayOneShot (PlayerDeathSound);

			playerCurrentHealth = 100;

			MoneyManager.ResetCurrency (ResetMoney);

			ScoreManager.ResetScore (ResetPoints);

		}
	}

	public void HurtPlayer(int damageToGive)
	{
		playerCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth()
	{
		playerCurrentHealth = playerMaxHealth;
	}

	public void AddHealth(int healthToGive)
	{
		playerCurrentHealth += healthToGive;
	}


}
