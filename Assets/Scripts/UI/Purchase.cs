using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class Purchase : MonoBehaviour
{
	public void Purchase20k()
    {
		PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 20000);
	}
	public void Purchase50k()
    {
		PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 50000);
	}
	public void Purchase100k()
    {
		PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 100000);
	}
	public void Purchase200k()
    {
		PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 200000);
	}
	public void Purchase400k()
    {
		PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 400000);
	}
	public void Purchase10D()
    {
		PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + 10);
	}
	public void Purchase25D()
    {
		PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + 25);
	}
	public void Purchase50D()
    {
		PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + 50);
	}
	public void Purchase100D()
    {
		PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + 100);
	}
	public void Purchase250D()
    {
		PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + 250);
	}
	public void PurchaseRemoveAdsPackage()
    {
		PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 100000);
		PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + 50);
		PlayerPrefs.SetInt("NoAds", 1);
	}
	public void PurchaseAllVehicles()
	{
		PlayerPrefs.SetInt("Veh1Owned", 1);
		PlayerPrefs.SetInt("Veh2Owned", 1);
		PlayerPrefs.SetInt("Veh3Owned", 1);
		PlayerPrefs.SetInt("Veh4Owned", 1);
		PlayerPrefs.SetInt("Veh5Owned", 1);
		PlayerPrefs.SetInt("Veh6Owned", 1);
		PlayerPrefs.SetInt("Veh7Owned", 1);
		PlayerPrefs.SetInt("Veh8Owned", 1);
		PlayerPrefs.SetInt("Veh9Owned", 1);
		PlayerPrefs.SetInt("Veh10Owned", 1);
		PlayerPrefs.SetInt("Veh11Owned", 1);
		PlayerPrefs.SetInt("Veh12Owned", 1);
		PlayerPrefs.SetInt("Veh13Owned", 1);
		PlayerPrefs.SetInt("Veh14Owned", 1);
	}
	public void PurchaseAllCityVehicles()
	{
		PlayerPrefs.SetInt("Veh5Owned", 1);
		PlayerPrefs.SetInt("Veh6Owned", 1);
		PlayerPrefs.SetInt("Veh7Owned", 1);
		PlayerPrefs.SetInt("Veh8Owned", 1);
		PlayerPrefs.SetInt("Veh9Owned", 1);
		PlayerPrefs.SetInt("Veh10Owned", 1);
		PlayerPrefs.SetInt("Veh11Owned", 1);
		PlayerPrefs.SetInt("Veh12Owned", 1);
		PlayerPrefs.SetInt("Veh13Owned", 1);
		PlayerPrefs.SetInt("Veh14Owned", 1);
	}
	public void PurchaseAllOffRoadVehicles()
	{
		PlayerPrefs.SetInt("Veh1Owned", 1);
		PlayerPrefs.SetInt("Veh2Owned", 1);
		PlayerPrefs.SetInt("Veh3Owned", 1);
		PlayerPrefs.SetInt("Veh4Owned", 1);
	}
}