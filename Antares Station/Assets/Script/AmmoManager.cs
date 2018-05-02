using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoManager : MonoBehaviour {

	public static int CurrentAmmo;

	TextMeshProUGUI text;

	public static AmmoManager Me;

	void Start () 
	{
		AmmoManager.Me = this;
		text = GetComponent<TextMeshProUGUI>();

	}

	void Update () 
	{

		if (CurrentAmmo < 0)
			CurrentAmmo = 0;

		text.text = "" + CurrentAmmo;


	}
		

	public static void AmmoCount (int Ammo)
	{
		CurrentAmmo = Ammo;
	}

	public static void AddAmmo(int ammoToGive)
	{
		CurrentAmmo += ammoToGive;
	}
		
}
