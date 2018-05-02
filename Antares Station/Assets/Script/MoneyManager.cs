using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour {

	public static int money;

	TextMeshProUGUI text;

	public static MoneyManager Me;


	void Start () 
	{
		MoneyManager.Me = this;

		text = GetComponent<TextMeshProUGUI> ();

		money = 0;
	}

	void Update () 
	{
		if (money < 0)
			money = 0;

		text.text = "" + money;
	}

	public static void AddPoints (int pointsToAdd)
	{
		money += pointsToAdd;
	}

	public static void ResetCurrency (int ResetMoney)
	{
		money = ResetMoney;
	}

	public static void TakePointsforHealth (int PointsToTake)
	{
		money -= PointsToTake;
	}
}
