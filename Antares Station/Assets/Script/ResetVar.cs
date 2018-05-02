using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetVar : MonoBehaviour {

	public static int StartingAmmo = 30;
		

	public static void AmmoStart (int Ammo)
	{
		Ammo = StartingAmmo;
	}
}
