using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Advertisements;
public class MainMenu : MonoBehaviour
{
	public int startingScore;
	public int startingDiamond;
	public TMP_Text MoneyValue;
	public TMP_Text DiamondValue;

	public Button CityButton;
	public Button OffRoadButton;
	public Button TrafficRiderButton;
	public GameObject CityWarningText;
	public GameObject OffroadWarningText;
	public GameObject TrafficRiderText;
	public Slider volumeSlider;
	public GameObject RateUsMenu;

	string gameId = "4205809";

	// Start is called before the first frame update
	void Start()
	{
		Advertisement.Initialize(gameId);
		if (!PlayerPrefs.HasKey("NewPlayer"))
		{
			//GameMultiLang.cs'e ta��nd�.
			/*if (Application.systemLanguage == SystemLanguage.Turkish)
            {
				PlayerPrefs.SetInt("_language", 1); //TURKISH
				PlayerPrefs.SetString("_language", "tr");
			}
			else
            {
				PlayerPrefs.SetInt("_language", 0); //ENGLISH
				PlayerPrefs.SetString("_language", "en");
			}*/

			//print("NewPlayerDetected.");
			PlayerPrefs.SetInt("NewPlayer", 1);
			PlayerPrefs.SetInt("PlayerClass", 0); //0 = AllClasses 1 = City 2 = OffRoad
			PlayerPrefs.SetInt("Coins", startingScore);
			PlayerPrefs.SetInt("Diamond", startingDiamond);
			PlayerPrefs.SetInt("SelectedRCCVehicle", 0);
			PlayerPrefs.SetInt("FirstDailyReward", 0);
			PlayerPrefs.SetInt("FirstGift", 0);
			PlayerPrefs.SetInt("DontShowRateUs", 0);
			PlayerPrefs.SetFloat("musicVolume", 1);
			PlayerPrefs.SetInt("NoAds", 0); // 1 == Noads
			QualitySettings.SetQualityLevel(3);
			PlayerPrefs.SetInt("GraphicsQuality",3);
			//StarPerScene
			PlayerPrefs.SetInt("StarP", 0); //Proto
			PlayerPrefs.SetInt("StarC", 0); //City
			PlayerPrefs.SetInt("StarCTT", 0); //CityTimeTrail
			PlayerPrefs.SetInt("StarS", 0); //Swamp
			PlayerPrefs.SetInt("StarSTT", 0); //SwampTimeTrail
			//LevelSetup
			PlayerPrefs.SetInt("LevelIDPrototype", 0);
			PlayerPrefs.SetInt("LevelNumPrototype", 1);
			PlayerPrefs.SetInt("LevelXPPrototype", 1);

			PlayerPrefs.SetInt("LevelIDCity", 0);
			PlayerPrefs.SetInt("LevelNumCity", 1);
			PlayerPrefs.SetInt("LevelXPCity", 1);
			PlayerPrefs.SetInt("LevelIDCityTT", 0);
			PlayerPrefs.SetInt("LevelNumCityTT", 1);
			PlayerPrefs.SetInt("LevelXPCityTT", 1);

			PlayerPrefs.SetInt("LevelIDSwamp", 0);
			PlayerPrefs.SetInt("LevelNumSwamp", 1);
			PlayerPrefs.SetInt("LevelXPSwamp", 1);
			PlayerPrefs.SetInt("LevelIDSwampTT", 0);
			PlayerPrefs.SetInt("LevelNumSwampTT", 1);
			PlayerPrefs.SetInt("LevelXPSwampTT", 1);
			//Vehicles
			PlayerPrefs.SetInt("Veh0Owned", 1);
			PlayerPrefs.SetInt("Veh1Owned", 0);
			PlayerPrefs.SetInt("Veh2Owned", 0);
			PlayerPrefs.SetInt("Veh3Owned", 0);
			PlayerPrefs.SetInt("Veh4Owned", 0);
			PlayerPrefs.SetInt("Veh5Owned", 0);
			PlayerPrefs.SetInt("Veh6Owned", 0);
			PlayerPrefs.SetInt("Veh7Owned", 0);
			PlayerPrefs.SetInt("Veh8Owned", 0);
			PlayerPrefs.SetInt("Veh9Owned", 0);
			PlayerPrefs.SetInt("Veh10Owned", 0);
			PlayerPrefs.SetInt("Veh11Owned", 0);
			PlayerPrefs.SetInt("Veh12Owned", 0);
			PlayerPrefs.SetInt("Veh13Owned", 0);
			PlayerPrefs.SetInt("Veh14Owned", 0);
			PlayerPrefs.SetInt("Veh15Owned", 0);
			PlayerPrefs.SetInt("Veh16Owned", 0);
			PlayerPrefs.SetInt("Veh17Owned", 0);
			PlayerPrefs.SetInt("Veh18Owned", 0);
			PlayerPrefs.SetInt("Veh19Owned", 0);
			PlayerPrefs.SetInt("Veh20Owned", 0);
			//VehiclePrices
			PlayerPrefs.SetInt("Veh0Price", 0);
			PlayerPrefs.SetInt("Veh1Price", 15000);
			PlayerPrefs.SetInt("Veh2Price", 27500);
			PlayerPrefs.SetInt("Veh3Price", 35000);
			PlayerPrefs.SetInt("Veh4Price", 45000);
			PlayerPrefs.SetInt("Veh5Price", 15000);
			PlayerPrefs.SetInt("Veh6Price", 25000);
			PlayerPrefs.SetInt("Veh7Price", 37500);
			PlayerPrefs.SetInt("Veh8Price", 35000);
			PlayerPrefs.SetInt("Veh9Price", 42500);
			PlayerPrefs.SetInt("Veh10Price", 47500);
			PlayerPrefs.SetInt("Veh11Price", 60000);
			PlayerPrefs.SetInt("Veh12Price", 30);
			PlayerPrefs.SetInt("Veh13Price", 40);
			PlayerPrefs.SetInt("Veh14Price", 50);
			PlayerPrefs.SetInt("Veh15Price", 5);
			PlayerPrefs.SetInt("Veh16Price", 5);
			PlayerPrefs.SetInt("Veh17Price", 5);
			PlayerPrefs.SetInt("Veh18Price", 5);
			PlayerPrefs.SetInt("Veh19Price", 5);
			PlayerPrefs.SetInt("Veh20Price", 5);

			PlayerPrefs.SetInt("Veh1PriceDiamond", 2);
			PlayerPrefs.SetInt("Veh2PriceDiamond", 5);
			PlayerPrefs.SetInt("Veh3PriceDiamond", 10);
			PlayerPrefs.SetInt("Veh4PriceDiamond", 15);
			PlayerPrefs.SetInt("Veh5PriceDiamond", 5);
			PlayerPrefs.SetInt("Veh6PriceDiamond", 7);
			PlayerPrefs.SetInt("Veh7PriceDiamond", 10);
			PlayerPrefs.SetInt("Veh8PriceDiamond", 5);
			PlayerPrefs.SetInt("Veh9PriceDiamond", 10);
			PlayerPrefs.SetInt("Veh10PriceDiamond", 15);
			PlayerPrefs.SetInt("Veh11PriceDiamond", 20);
			PlayerPrefs.SetInt("Veh15PriceDiamond", 0);
			PlayerPrefs.SetInt("Veh16PriceDiamond", 0);
			PlayerPrefs.SetInt("Veh17PriceDiamond", 0);
			PlayerPrefs.SetInt("Veh18PriceDiamond", 0);
			PlayerPrefs.SetInt("Veh19PriceDiamond", 0);
			PlayerPrefs.SetInt("Veh20PriceDiamond", 0);

			//
			LoadVolume();
		}
		else
        {
			LoadVolume();
			LoadGraphics();
			if(!PlayerPrefs.HasKey("RatedUs"))
            {
				if(PlayerPrefs.GetInt("DontShowRateUs") == 0)
                {
					if (PlayerPrefs.GetInt("LevelIDPrototype") == 5 || PlayerPrefs.GetInt("LevelIDCity") == 6 || PlayerPrefs.GetInt("LevelIDCity") == 6 || PlayerPrefs.GetInt("LevelIDPrototype") == 11 || PlayerPrefs.GetInt("LevelIDCity") == 12 || PlayerPrefs.GetInt("LevelIDCity") == 12)
					{
						RateUsMenu.SetActive(true);
					}
				}
			}
		}
		//MoneyValue.text = PlayerPrefs.GetInt("Coins").ToString();
		//DiamondValue.text = PlayerPrefs.GetInt("Diamond").ToString();
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
		MoneyValue.text = PlayerPrefs.GetInt("Coins").ToString() + "$";
		DiamondValue.text = PlayerPrefs.GetInt("Diamond").ToString();
	}
	/*
    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.W))
		{
			PlayerPrefs.DeleteAll();
			Debug.Log("PlayerPrefs.DeleteAll ();");
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 10000);
			Debug.Log("10.000$ Added to your Account.");
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + 10);
			Debug.Log("10 Diamond Added to your Account.");
		}
		if (Input.GetKeyDown(KeyCode.G))
		{
			PlayerPrefs.SetInt("LevelIDCity", 30);
			Debug.Log("LevelIDCity == 30");
		}
	}

	public void GiveMoney()
    {
		PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 10000);
		PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + 10);
	}*/
	
    public void CheckVehicle()
    {
		if (PlayerPrefs.GetInt("PlayerClass") == 0)
		{
			CityWarningText.SetActive(true);
			CityButton.interactable = false;
			OffRoadButton.interactable = false;
			OffroadWarningText.SetActive(true);
		}
		else if (PlayerPrefs.GetInt("PlayerClass") == 1)
		{
			OffRoadButton.interactable = false;
			OffroadWarningText.SetActive(true);
			CityWarningText.SetActive(false);
			CityButton.interactable = true;
		}
		else if (PlayerPrefs.GetInt("PlayerClass") == 2)
		{
			CityWarningText.SetActive(true);
			CityButton.interactable = false;
			OffRoadButton.interactable = true;
			OffroadWarningText.SetActive(false);
		}
		//GameMode
		if (PlayerPrefs.GetInt("LevelIDCity") >= 30 || PlayerPrefs.GetInt("LevelIDCityTT") >= 30 || PlayerPrefs.GetInt("LevelIDSwamp") >= 30 || PlayerPrefs.GetInt("LevelIDSwampTT") >= 30)
		{
			TrafficRiderButton.interactable = true;
			TrafficRiderText.SetActive(false);
		}
		else
		{
			TrafficRiderButton.interactable = false;
			TrafficRiderText.SetActive(true);
		}
	}

	int AdChance;
	public void AdOnChance()
    {
		AdChance = UnityEngine.Random.Range(0, 10);
		if (AdChance >= 8)
			PlayAdonMenu();
	}

	public void PlayAdonMenu()
	{
		if (PlayerPrefs.GetInt("NoAds") == 0)
		{
			if (Advertisement.IsReady("Interstitial_Android"))
			{
				Advertisement.Show("Interstitial_Android");
			}
		}
	}

	public void ChangeVolume()
	{
		AudioListener.volume = volumeSlider.value;
		SaveVolume();
	}

	private void LoadVolume()
	{
		volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
	}

	private void LoadGraphics()
	{
		QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicsQuality"));
	}

	private void SaveVolume()
	{
		PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
	}
	public void SetTrue(GameObject target)
	{
		target.SetActive(true);
	}

	public void SetFalse(GameObject target)
	{
		target.SetActive(false);
	}

	public void ToggleObject(GameObject target)
	{
		target.SetActive(!target.activeSelf);
	}

	public void LoadLevel(string name)
	{

		//Loading.SetActive(true);
		SceneManager.LoadSceneAsync(name);
	}

	public void SetQualityLow()
    {
		QualitySettings.SetQualityLevel(0);
		PlayerPrefs.SetInt("GraphicsQuality",0);
    }
	public void SetQualityMedium()
	{
		QualitySettings.SetQualityLevel(1);
		PlayerPrefs.SetInt("GraphicsQuality",1);
	}
	public void SetQualityHigh()
	{
		QualitySettings.SetQualityLevel(2);
		PlayerPrefs.SetInt("GraphicsQuality",2);
	}
	public void SetQualityUltra()
	{
		QualitySettings.SetQualityLevel(3);
		PlayerPrefs.SetInt("GraphicsQuality",3);
	}

	public void SetMobileController1()
    {
		RCC.SetMobileController(RCC_Settings.MobileController.TouchScreen);
	}
	public void SetMobileController2()
	{
		RCC.SetMobileController(RCC_Settings.MobileController.Joystick);
	}
	public void SetMobileController3()
	{
		RCC.SetMobileController(RCC_Settings.MobileController.SteeringWheel);
	}
	public void SetMobileController4()
	{
		RCC.SetMobileController(RCC_Settings.MobileController.Gyro);
	}

	//DROPDOWN INPUTHANDLE
	public void HandleInputData(int val)
	{
		if (val == 0)
		{
			print("Select the Language");
		}
		if (val == 1)
		{
			PlayerPrefs.SetInt("_language", 0);
			PlayerPrefs.SetString("_language", "en");
		}
		if (val == 2)
		{
			PlayerPrefs.SetInt("_language", 1);
			PlayerPrefs.SetString("_language", "tr");
		}
		if (val == 3)
		{
			PlayerPrefs.SetInt("_language", 2);
			PlayerPrefs.SetString("_language", "fr");
		}
		if (val == 4)
		{
			PlayerPrefs.SetInt("_language", 3);
			PlayerPrefs.SetString("_language", "de");
		}
		if (val == 5)
		{
			PlayerPrefs.SetInt("_language", 4);
			PlayerPrefs.SetString("_language", "sp");
		}
	}

	public void ApplyLanguageChanges()
	{
		SceneManager.LoadScene(1);
	}
	//SOCIALMEDIA
	public void DiscordButton()
    {
		Application.OpenURL("https://discord.gg/tZNUeQdAaM");
	}
	public void mailButton()
	{
		Application.OpenURL("mailto:gamefabrikateam@gmail.com");
	}
	public void youtubeButton()
	{
		Application.OpenURL("https://www.youtube.com/c/ParkingMasterAsphaltOffRoad/");
	}
	public void instaButton()
	{
		Application.OpenURL("https://www.instagram.com/parkingmastergame/");
	}
	public void twitterButton()
	{
		Application.OpenURL("https://twitter.com/parkmastergame");
	}


}

//PlayerPref Boolean Y�ntemi
//PlayerPrefs.SetInt("Name", (yourBool ? 1 : 0));
//yourBool = (PlayerPrefs.GetInt("Name") != 0);