using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
using UnityEngine.Advertisements;
public class ParkingManager: MonoBehaviour, IUnityAdsListener
{
	    
    string gameId = "4205809";
	//Ads
	[Header("Ads")]
	[SerializeField] Button RewardButton;
	int AdChance;
	//---------------------------------------------------------------------------
	[HideInInspector]
	public bool t1, t2, t3, t0, tFront, tBack;
	//---------------------------------------------------------------------------
	// This variables for internal usage
	bool FinisheD = false;
	bool started = false;
	[Header("Gerekenler")]
	//public RCC_CarControllerV3 Controller;
	public RCC_SceneManager sceneManager;
	//Park place renderer for changing color => green or white
	public MeshRenderer ParkRenderer;
	public MeshRenderer LightBeam;
	public Texture mainBeamTexture;
	public Texture NewBeamTexture;
	//---------------------------------------------------------------------------
	[Header("Bildirimler")]
	string carParkedHeader;
	string carParkedContent;
	bool notNotification = false;
	//---------------------------------------------------------------------------
	// Is time limited?
	[Header("Zaman Sınırı")]
	bool timeLimit;
	float endTime;
	//Timer CountDown Text
	public TMP_Text CountDownText;
	// Activated when yime limiter is on acrive mode
	public GameObject TimeDownMenu;
	public float seconds = 0; // Amount of seconds 
	public float minutes = 0; //Amount of minutes Text _text;
	public float minuteTimer = 0;
	public float secondTimer = 0;
	//---------------------------------------------------------------------------
	[HideInInspector] public int CollisionCount; //Collision Count
	[Header("Collision Hit Manager")]
	public TMP_Text CollistionCountText;  //Collistion Count Text
	public int CollisionLimit;
	public int CollisionScore0;
	public int CollisionScore1;
	public int CollisionScore2;
	public int CollisionScore3;
	[Header("Mobile Controller")]
	public GameObject MobileController;
	[Header("Fail Menu")]
	bool Failed = false;
	bool timeFailed = false;
	public GameObject FailedMenu;
	public TextMeshProUGUI ScoreInt;
	public TextMeshProUGUI FailHeader;
	[Header("Success Menu")]
	public GameObject SuccessMenu;
	public TMP_Text bestTime, currentTime;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	public TMP_Text FinishScoreText;
	[Header("Diamond Reward")]
	public bool isDiamondRewarded;
	public int DiamondReward;
	public GameObject DiamondRewardMenu;
	public TMP_Text DiamondRewardText;
	[Header("TooltipDefaults")]
	string GameStartedContent;
	string GameStartedHeader; 
	IEnumerator Start()
	{

		if (PlayerPrefs.GetString("_language") == "tr")
		{
			carParkedContent = "Aracı park ettiniz! Şimdi aracınızı Park moduna alın.";
			carParkedHeader = "Park Edildi!";
			GameStartedContent = "Aracinizi calistirmadan once lutfen kemerinizi baglayin.";
			GameStartedHeader = "Kemerinizi Baglayin";
		}else if (PlayerPrefs.GetString("_language") == "fr")
		{
			carParkedContent = "Vous avez gare le vehicule ! Maintenant, mettez votre voiture en mode Park.";
			carParkedHeader = "Stationne !";
			GameStartedContent = "Veuillez attacher votre ceinture de sécurité avant de démarrer votre véhicule.";
			GameStartedHeader = "Attachez votre ceinture";
		}else if (PlayerPrefs.GetString("_language") == "sp")
		{
			carParkedContent = "Estacionaste el vehiculo! Ahora ponga su automovil en modo de estacionamiento.";
			carParkedHeader = "Estacionado!";
			GameStartedContent = "Abróchese el cinturón de seguridad antes de arrancar su vehículo. ";
			GameStartedHeader = "Abróchate el cinturón";
		}else if (PlayerPrefs.GetString("_language") == "de")
		{
			carParkedContent = "Sie haben das Fahrzeug geparkt! Versetzen Sie Ihr Auto nun in den Park-Modus.";
			carParkedHeader = "Geparkt!";
			GameStartedContent = "Bitte legen Sie Ihren Sicherheitsgurt an, bevor Sie Ihr Fahrzeug starten.";
			GameStartedHeader = "Befestigen am Gürtel";
		}
		else
		{
			carParkedContent = "You have parked your Car. Now put your car in Park mode.";
			carParkedHeader = "Car Parked!";
			GameStartedContent = "Please fasten your seat belt before starting your vehicle.";
			GameStartedHeader = "Fasten Your Belt";
		}

		Advertisement.Initialize(gameId);
		Advertisement.AddListener(this);
		Advertisement.Banner.Hide();
		Initialize();
		if (SceneManager.GetActiveScene().name == "PrototypeScene")
		{
			timeLimit = false;
		}
		else if (SceneManager.GetActiveScene().name == "CityScene")
		{
			timeLimit = false;
		}
		else if (SceneManager.GetActiveScene().name == "CitySceneTT")
		{
			timeLimit = true;
		}
		else if (SceneManager.GetActiveScene().name == "SwampMap")
		{
			timeLimit = false;
		}
		else if (SceneManager.GetActiveScene().name == "SwampMapTT")
		{
			timeLimit = true;
		}

		started = true;
		
		if (SceneManager.GetActiveScene().name != "PrototypeScene")
		{
			if (PlayerPrefs.GetInt("LevelIDCity") != 3 ||
			PlayerPrefs.GetInt("LevelIDCity") != 8 || 
			PlayerPrefs.GetInt("LevelIDCity") != 12 || 
			PlayerPrefs.GetInt("LevelIDCity") != 20 || 
			PlayerPrefs.GetInt("LevelIDCity") != 21 || 
			PlayerPrefs.GetInt("LevelIDCity") != 23 || 
			PlayerPrefs.GetInt("LevelIDCity") != 25 || 
			PlayerPrefs.GetInt("LevelIDCity") != 26 || 
			PlayerPrefs.GetInt("LevelIDCity") != 28 ||
			PlayerPrefs.GetInt("LevelIDCity") != 33 ||
			PlayerPrefs.GetInt("LevelIDCity") != 38 ||
			PlayerPrefs.GetInt("LevelIDCity") != 38 ||
			PlayerPrefs.GetInt("LevelIDCity") != 42 ||
			PlayerPrefs.GetInt("LevelIDCity") != 44 ||
			PlayerPrefs.GetInt("LevelIDCity") != 48)
				TooltipSystem.Show(GameStartedContent, GameStartedHeader);
		else if (PlayerPrefs.GetInt("LevelIDCityTT") != 3 ||
			PlayerPrefs.GetInt("LevelIDCityTT") != 8 || 
			PlayerPrefs.GetInt("LevelIDCityTT") != 12 || 
			PlayerPrefs.GetInt("LevelIDCityTT") != 20 || 
			PlayerPrefs.GetInt("LevelIDCityTT") != 21 || 
			PlayerPrefs.GetInt("LevelIDCityTT") != 23 || 
			PlayerPrefs.GetInt("LevelIDCityTT") != 25 || 
			PlayerPrefs.GetInt("LevelIDCityTT") != 26 || 
			PlayerPrefs.GetInt("LevelIDCityTT") != 28 ||
			PlayerPrefs.GetInt("LevelIDCityTT") != 33 ||
			PlayerPrefs.GetInt("LevelIDCityTT") != 38 ||
			PlayerPrefs.GetInt("LevelIDCityTT") != 38 ||
			PlayerPrefs.GetInt("LevelIDCityTT") != 42 ||
			PlayerPrefs.GetInt("LevelIDCityTT") != 44 ||
			PlayerPrefs.GetInt("LevelIDCityTT") != 48)
				TooltipSystem.Show(GameStartedContent, GameStartedHeader);
		else if (PlayerPrefs.GetInt("LevelIDSwamp") != 9 || 
			PlayerPrefs.GetInt("LevelIDSwamp") != 15 || 
			PlayerPrefs.GetInt("LevelIDSwamp") != 17 || 
			PlayerPrefs.GetInt("LevelIDSwamp") != 23 || 
			PlayerPrefs.GetInt("LevelIDSwamp") != 28 || 
			PlayerPrefs.GetInt("LevelIDSwamp") != 30 || 
			PlayerPrefs.GetInt("LevelIDSwamp") != 39)
				TooltipSystem.Show(GameStartedContent, GameStartedHeader);
		else if (PlayerPrefs.GetInt("LevelIDSwamp") != 9 || 
			PlayerPrefs.GetInt("LevelIDSwamp") != 15 || 
			PlayerPrefs.GetInt("LevelIDSwamp") != 17 || 
			PlayerPrefs.GetInt("LevelIDSwamp") != 23 || 
			PlayerPrefs.GetInt("LevelIDSwamp") != 28 || 
			PlayerPrefs.GetInt("LevelIDSwamp") != 30 || 
			PlayerPrefs.GetInt("LevelIDSwamp") != 39)
				TooltipSystem.Show(GameStartedContent, GameStartedHeader);
		}
					
		endTime = Time.time + 4;
		yield return new WaitForSeconds(.03f);
	}
	
    void Update ()
	{
		if (Input.GetKeyDown (KeyCode.V))
			Debug.Log (" t0 " + t0 + " t1 " + t1 + " t2 " + t2 + " t3 " + t3 + " tFront " + tFront + " tBack " + tBack);
			
		// Is parking finished?
		if (!FinisheD) {// No ,parking isn't finish, check parking state
			if (t0 && t2 && t3 && t1 && tFront && tBack) {// If all of car triggers being entered in parking place
				ParkRenderer.material.color = Color.green;
				LightBeam.material.SetTexture("_MainTex", NewBeamTexture);
				Debug.Log("Park edildi, vitesi Park moduna alın.");
				if (!notNotification)
                {
					TooltipSystem.Show(carParkedContent, carParkedHeader);
					notNotification = true;
				}
				
				if (sceneManager.activePlayerVehicle.NGear)
                {
					TooltipSystem.Hide();
					RCC.SetEngine(sceneManager.activePlayerVehicle, false);
					//Controller.engineRunning = false;
					FinisheD = true;
					Success();
					Debug.Log("Bölüm Bitirildi.");
				}				
			} else {// Car doesn't on correct parking place
				endTime = Time.time + 4;
				ParkRenderer.material.color = Color.white;
				LightBeam.material.SetTexture("_MainTex", mainBeamTexture);
			}
		}
		
		if (timeLimit)
			TimeDown();
		if (started)
			Timer();
	}

	void Initialize()
	{
		RewardButton.onClick.RemoveAllListeners();
		RewardButton.onClick.AddListener(OnRewardButtonClick);
	}

	void OnRewardButtonClick()
	{
		if (Advertisement.IsReady("Rewarded_Android"))
		{
			Advertisement.Show("Rewarded_Android");
		}
	}

	public void PlayAd()
	{
		if (PlayerPrefs.GetInt("NoAds") == 0)
        {
			if (Advertisement.IsReady("Interstitial_Android"))
			{
				Advertisement.Show("Interstitial_Android");
			}
		}
	}

	public void TimeDown()
	{

		if (seconds <= 0)
		{
			seconds = 59;

			if (minutes >= 1)
			{
				minutes--;
			}
			else
			{
				minutes = 0;
				seconds = 0;
				CountDownText.text = minutes.ToString("f0") + ":0" + seconds.ToString("f0");
				if(!Failed && !timeFailed)
                {
					TimeFailed();
				}					
			}
		}
		else
		{
			seconds -= Time.deltaTime;
			string min;
			string sec;

			if (minutes < 10)
				min = "0" + minutes.ToString();
			else
				min = minutes.ToString();

			if (seconds < 10)
				sec = "0" + (Mathf.FloorToInt(seconds)).ToString();
			else
				sec = (Mathf.FloorToInt(seconds)).ToString();

			CountDownText.text = min + ":" + sec;
		}
	}

	public void Timer()
	{
		if(FinisheD || Failed || timeFailed)
        {}
		else
        {
			secondTimer += Time.deltaTime;
			string minTimer;
			string secTimer;

			if (minuteTimer < 10)
				minTimer = "0" + minuteTimer.ToString();
			else
				minTimer = minuteTimer.ToString();

			if (secondTimer < 10)
				secTimer = "0" + (Mathf.FloorToInt(secondTimer)).ToString();
			else
				secTimer = (Mathf.FloorToInt(secondTimer)).ToString();

			if (Mathf.FloorToInt(secondTimer) >= 59)
			{
				secondTimer = 0;
				minuteTimer++;
			}
			if(!timeLimit)
			CountDownText.text = minTimer + ":" + secTimer;
			//print(minTimer + ":" + secTimer);
		}		
	}

	public void TimeFailed()
	{
		Failed = true;
		FailedMenu.transform.DOScale(0, 0.25f)
			.SetEase(Ease.InOutQuart)
			.OnStepComplete(() =>
			{
				RCC.SetEngine(sceneManager.activePlayerVehicle, false);
				FailedMenu.SetActive(true);
				//ScoreInt.text = "Your score is: 0";

				if (PlayerPrefs.GetString("_language") == "tr")
				FailHeader.text = "Sureniz doldu.";
				else if (PlayerPrefs.GetString("_language") == "fr")
				FailHeader.text = "Ton temps est fini.";
				else if (PlayerPrefs.GetString("_language") == "sp")
				FailHeader.text = "Tu tiempo se ha acabado.";
				else if (PlayerPrefs.GetString("_language") == "de")
				FailHeader.text = "Deine Zeit ist vorbei.";
				else
				FailHeader.text = "Your time is over.";
				
				FailedMenu.transform.DOScale(1, 0.25f)
				   .SetEase(Ease.InOutQuart);
				AdChance = UnityEngine.Random.Range(0, 10);
				if(AdChance >= 5)
				PlayAd();
				else
                {
					if (Advertisement.IsReady("Banner_Android"))
					{
						Advertisement.Banner.Show("Banner_Android");
						Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
					}
				}
			});
	}

	public void CollisionFailed()
    {
		if(!Failed)
        {
			Failed = true;
			RCC.SetEngine(sceneManager.activePlayerVehicle, false);
			FailedMenu.transform.DOScale(0, 0.25f)
				.SetEase(Ease.InOutQuart)
				.OnStepComplete(() =>
				{
					FailedMenu.SetActive(true);
					//ScoreInt.text = "Your score is: 0";
					FailedMenu.transform.DOScale(1, 0.25f)
				   .SetEase(Ease.InOutQuart);
					AdChance = UnityEngine.Random.Range(0, 10);
					if (AdChance >= 5)
						PlayAd();
					else
					{
						if (PlayerPrefs.GetInt("NoAds") == 0)
                        {
							if (Advertisement.IsReady("Banner_Android"))
							{
								Advertisement.Banner.Show("Banner_Android");
								Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
							}
						}
					}
				});
		}
    }

	public void Success()
	{
		if(FinisheD)
        {
			AdChance = UnityEngine.Random.Range(0, 10);
			if (AdChance >= 9)
				PlayAd();
			else
            {
				if (PlayerPrefs.GetInt("NoAds") == 0)
				{
					if (Advertisement.IsReady("Banner_Android"))
					{
						Advertisement.Banner.Show("Banner_Android");
						Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
					}
				}
			}

			if (SceneManager.GetActiveScene().name == "PrototypeScene")
			{
				if (CollisionCount == 0)
				{// Score given to player when collision detection is 0
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore0);
					// Show earned score on finish menu
					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore0.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore0.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore0.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore0.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore0.ToString() + "$";
					star3.SetActive(true);
					//PlayerPrefs.SetInt("StarP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), 3);
					//As.clip = clipSucces;
					//As.Play();
					if (PlayerPrefs.GetInt("StarP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) < 3)
					{
						PlayerPrefs.SetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), secondTimer);
						if (isDiamondRewarded)
						{
							PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + DiamondReward);
							if (PlayerPrefs.GetString("_language") == "tr")
								DiamondRewardText.text = "Senin icin " + DiamondReward + "x Elmas hediyemiz var!";
							else if (PlayerPrefs.GetString("_language") == "fr")
								DiamondRewardText.text = "Nous avons " + DiamondReward + "x Diamants pour vous!";
							else if (PlayerPrefs.GetString("_language") == "sp")
								DiamondRewardText.text = "Tenemos " + DiamondReward + "x regalos de diamantes para ti";
							else if (PlayerPrefs.GetString("_language") == "de")
								DiamondRewardText.text = "Wir haben " + DiamondReward + "x Diamantgeschenke fur Sie!";
							else
								DiamondRewardText.text = "We have " + DiamondReward + "x Diamond Bonus for you!";
							DiamondRewardMenu.transform.DOScale(0, 0.25f)
							.SetEase(Ease.InOutQuart)
							.OnStepComplete(() =>
							{
								DiamondRewardMenu.SetActive(true);
								DiamondRewardMenu.transform.DOScale(1, 0.25f)
								   .SetEase(Ease.InOutQuart);
							});
						}
					}
					if (PlayerPrefs.GetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) == minuteTimer)
					{

						if (PlayerPrefs.GetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) > secondTimer)
								PlayerPrefs.SetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) > minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("StarP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), 3);
					PlayerPrefs.SetInt("LevelXPPrototype", PlayerPrefs.GetInt("LevelXPPrototype") + CollisionScore0);
					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}
				if (CollisionCount == 1)
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore1);

					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore1.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore1.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore1.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore1.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore1.ToString() + "$";
					star2.SetActive(true);
					PlayerPrefs.SetInt("StarP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), 2);
					//As.clip = clipSucces;
					//As.Play();
					if (!PlayerPrefs.HasKey("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()))
					{
						PlayerPrefs.SetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), secondTimer);
					}
					if (PlayerPrefs.GetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) == minuteTimer)
					{
						if (PlayerPrefs.GetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) < secondTimer)
								PlayerPrefs.SetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) < minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("LevelXPPrototype", PlayerPrefs.GetInt("LevelXPPrototype") + CollisionScore1);
					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}
				if (CollisionCount == 2)
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore2);

					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore2.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore2.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore2.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore2.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore2.ToString() + "$";
					star1.SetActive(true);
					PlayerPrefs.SetInt("StarP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), 1);
					//As.clip = clipSucces;
					//As.Play();
					if (!PlayerPrefs.HasKey("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()))
					{
						PlayerPrefs.SetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), secondTimer);
					}
					if (PlayerPrefs.GetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) == minuteTimer)
					{
						if (PlayerPrefs.GetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) < secondTimer)
								PlayerPrefs.SetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) < minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("LevelXPPrototype", PlayerPrefs.GetInt("LevelXPPrototype") + CollisionScore2);
					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}

				if (CollisionCount == 3)
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore3);

					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore3.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore3.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore3.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore3.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore3.ToString() + "$";
					//As.clip = clipLost;
					//As.Play();
					if (!PlayerPrefs.HasKey("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()))
					{
						PlayerPrefs.SetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), secondTimer);
					}
					if (PlayerPrefs.GetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) == minuteTimer)
					{
						if (PlayerPrefs.GetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) < secondTimer)
								PlayerPrefs.SetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) < minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsP" + PlayerPrefs.GetInt("LevelIDPrototype").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("LevelXPPrototype", PlayerPrefs.GetInt("LevelXPPrototype") + CollisionScore3);

					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}

				PlayerPrefs.SetInt("TotalPassedP", PlayerPrefs.GetInt("TotalPassedP") + 1);
				//print("TotalPassed Level:"+PlayerPrefs.GetInt("TotalPassed"));
				//---------------------------------------------------------------------------
				// Player passed one level up

				if (PlayerPrefs.GetInt("LevelIDPrototype") + 1 == PlayerPrefs.GetInt("LevelNumPrototype"))
				{
					PlayerPrefs.SetInt("LevelNumPrototype", PlayerPrefs.GetInt("LevelNumPrototype") + 1);
					PlayerPrefs.SetInt("PassedLevelsP", PlayerPrefs.GetInt("PassedLevelsP") + 1);
				}
				//print("LevelID:" + PlayerPrefs.GetInt("LevelID"));
				//Set the NextLevel ID
				PlayerPrefs.SetInt("LevelIDPrototype", PlayerPrefs.GetInt("LevelIDPrototype") + 1);
				//---------------
				SuccessMenu.transform.DOScale(0, 0.25f)
					.SetEase(Ease.InOutQuart)
					.OnStepComplete(() =>
					{
						SuccessMenu.SetActive(true);
						SuccessMenu.transform.DOScale(1, 0.25f)
						   .SetEase(Ease.InOutQuart);
					});
			}
			else if (SceneManager.GetActiveScene().name == "CityScene")
			{
				if (CollisionCount == 0)
				{// Score given to player when collision detection is 0
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore0);
					// Show earned score on finish menu
					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore0.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore0.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore0.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore0.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore0.ToString() + "$";
					star3.SetActive(true);
					
					//As.clip = clipSucces;
					//As.Play();
					if (PlayerPrefs.GetInt("StarC" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) < 3)
					{
						PlayerPrefs.SetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), secondTimer);
						if (isDiamondRewarded)
						{
							PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + DiamondReward);
							if (PlayerPrefs.GetString("_language") == "tr")
								DiamondRewardText.text = "Senin icin " + DiamondReward + "x Elmas hediyemiz var!";
							else if (PlayerPrefs.GetString("_language") == "fr")
								DiamondRewardText.text = "Nous avons " + DiamondReward + "x Diamants pour vous!";
							else if (PlayerPrefs.GetString("_language") == "sp")
								DiamondRewardText.text = "Tenemos " + DiamondReward + "x regalos de diamantes para ti";
							else if (PlayerPrefs.GetString("_language") == "de")
								DiamondRewardText.text = "Wir haben " + DiamondReward + "x Diamantgeschenke fur Sie!";
							else
								DiamondRewardText.text = "We have " + DiamondReward + "x Diamond Bonus for you!";
							DiamondRewardMenu.transform.DOScale(0, 0.25f)
							.SetEase(Ease.InOutQuart)
							.OnStepComplete(() =>
							{
								DiamondRewardMenu.SetActive(true);
								DiamondRewardMenu.transform.DOScale(1, 0.25f)
								   .SetEase(Ease.InOutQuart);
							});
						}
					}
					if (PlayerPrefs.GetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) == minuteTimer)
					{

						if (PlayerPrefs.GetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) > secondTimer)
								PlayerPrefs.SetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) > minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("StarC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), 3);
					PlayerPrefs.SetInt("LevelXPCity", PlayerPrefs.GetInt("LevelXPCity") + CollisionScore0);
					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}
				if (CollisionCount == 1)
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore1);

					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore1.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore1.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore1.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore1.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore1.ToString() + "$";
					star2.SetActive(true);
					PlayerPrefs.SetInt("StarC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), 2);
					//As.clip = clipSucces;
					//As.Play();
					if (!PlayerPrefs.HasKey("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString()))
					{
						PlayerPrefs.SetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), secondTimer);
					}
					if (PlayerPrefs.GetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) == minuteTimer)
					{
						if (PlayerPrefs.GetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) < secondTimer)
								PlayerPrefs.SetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) < minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("LevelXPCity", PlayerPrefs.GetInt("LevelXPCity") + CollisionScore1);
					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}
				if (CollisionCount == 2)
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore2);

					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore2.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore2.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore2.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore2.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore2.ToString() + "$";
					star1.SetActive(true);
					PlayerPrefs.SetInt("StarC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), 1);
					//As.clip = clipSucces;
					//As.Play();
					if (!PlayerPrefs.HasKey("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString()))
					{
						PlayerPrefs.SetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), secondTimer);
					}
					if (PlayerPrefs.GetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) == minuteTimer)
					{
						if (PlayerPrefs.GetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) < secondTimer)
								PlayerPrefs.SetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) < minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("LevelXPCity", PlayerPrefs.GetInt("LevelXPCity") + CollisionScore2);
					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}

				if (CollisionCount == 3)
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore3);

					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore3.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore3.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore3.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore3.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore3.ToString() + "$";
					//As.clip = clipLost;
					//As.Play();
					if (!PlayerPrefs.HasKey("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString()))
					{
						PlayerPrefs.SetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), secondTimer);
					}
					if (PlayerPrefs.GetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) == minuteTimer)
					{
						if (PlayerPrefs.GetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) < secondTimer)
								PlayerPrefs.SetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString()) < minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsC" + PlayerPrefs.GetInt("LevelIDCity").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("LevelXPCity", PlayerPrefs.GetInt("LevelXPCity") + CollisionScore3);

					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}

				PlayerPrefs.SetInt("TotalPassedP", PlayerPrefs.GetInt("TotalPassedP") + 1);
				//print("TotalPassed Level:"+PlayerPrefs.GetInt("TotalPassed"));
				//---------------------------------------------------------------------------
				// Player passed one level up

				if (PlayerPrefs.GetInt("LevelIDCity") + 1 == PlayerPrefs.GetInt("LevelNumCity"))
				{
					PlayerPrefs.SetInt("LevelNumCity", PlayerPrefs.GetInt("LevelNumCity") + 1);
					PlayerPrefs.SetInt("PassedLevelsP", PlayerPrefs.GetInt("PassedLevelsP") + 1);
				}
				//print("LevelID:" + PlayerPrefs.GetInt("LevelID"));
				//Set the NextLevel ID
				PlayerPrefs.SetInt("LevelIDCity", PlayerPrefs.GetInt("LevelIDCity") + 1);
				//---------------
				SuccessMenu.transform.DOScale(0, 0.25f)
					.SetEase(Ease.InOutQuart)
					.OnStepComplete(() =>
					{
						SuccessMenu.SetActive(true);
						SuccessMenu.transform.DOScale(1, 0.25f)
						   .SetEase(Ease.InOutQuart);
					});
			}
			else if (SceneManager.GetActiveScene().name == "CitySceneTT")
			{
				if (CollisionCount == 0)
				{// Score given to player when collision detection is 0
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore0);
					// Show earned score on finish menu
					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore0.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore0.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore0.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore0.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore0.ToString() + "$";
					star3.SetActive(true);
					
					//As.clip = clipSucces;
					//As.Play();
					if (PlayerPrefs.GetInt("StarCTT" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) < 3)
					{
						PlayerPrefs.SetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), secondTimer);
						if (isDiamondRewarded)
						{
							PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + DiamondReward);
							if (PlayerPrefs.GetString("_language") == "tr")
								DiamondRewardText.text = "Senin icin " + DiamondReward + "x Elmas hediyemiz var!";
							else if (PlayerPrefs.GetString("_language") == "fr")
								DiamondRewardText.text = "Nous avons " + DiamondReward + "x Diamants pour vous!";
							else if (PlayerPrefs.GetString("_language") == "sp")
								DiamondRewardText.text = "Tenemos " + DiamondReward + "x regalos de diamantes para ti";
							else if (PlayerPrefs.GetString("_language") == "de")
								DiamondRewardText.text = "Wir haben " + DiamondReward + "x Diamantgeschenke fur Sie!";
							else
								DiamondRewardText.text = "We have " + DiamondReward + "x Diamond Bonus for you!";
							DiamondRewardMenu.transform.DOScale(0, 0.25f)
							.SetEase(Ease.InOutQuart)
							.OnStepComplete(() =>
							{
								DiamondRewardMenu.SetActive(true);
								DiamondRewardMenu.transform.DOScale(1, 0.25f)
								   .SetEase(Ease.InOutQuart);
							});
						}
					}
					if (PlayerPrefs.GetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) == minuteTimer)
					{

						if (PlayerPrefs.GetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) > secondTimer)
								PlayerPrefs.SetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) > minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("StarCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), 3);
					PlayerPrefs.SetInt("LevelXPCityTT", PlayerPrefs.GetInt("LevelXPCityTT") + CollisionScore0);
					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}
				if (CollisionCount == 1)
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore1);

					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore1.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore1.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore1.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore1.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore1.ToString() + "$";
					star2.SetActive(true);
					PlayerPrefs.SetInt("StarCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), 2);
					//As.clip = clipSucces;
					//As.Play();
					if (!PlayerPrefs.HasKey("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()))
					{
						PlayerPrefs.SetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), secondTimer);
					}
					if (PlayerPrefs.GetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) == minuteTimer)
					{
						if (PlayerPrefs.GetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) < secondTimer)
								PlayerPrefs.SetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) < minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("LevelXPCityTT", PlayerPrefs.GetInt("LevelXPCityTT") + CollisionScore1);
					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}
				if (CollisionCount == 2)
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore2);

					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore2.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore2.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore2.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore2.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore2.ToString() + "$";
					star1.SetActive(true);
					PlayerPrefs.SetInt("StarCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), 1);
					//As.clip = clipSucces;
					//As.Play();
					if (!PlayerPrefs.HasKey("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()))
					{
						PlayerPrefs.SetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), secondTimer);
					}
					if (PlayerPrefs.GetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) == minuteTimer)
					{
						if (PlayerPrefs.GetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) < secondTimer)
								PlayerPrefs.SetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) < minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("LevelXPCityTT", PlayerPrefs.GetInt("LevelXPCityTT") + CollisionScore2);
					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}

				if (CollisionCount == 3)
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore3);

					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore3.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore3.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore3.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore3.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore3.ToString() + "$";
					//As.clip = clipLost;
					//As.Play();
					if (!PlayerPrefs.HasKey("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()))
					{
						PlayerPrefs.SetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), secondTimer);
					}
					if (PlayerPrefs.GetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) == minuteTimer)
					{
						if (PlayerPrefs.GetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) < secondTimer)
								PlayerPrefs.SetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString()) < minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsCTT" + PlayerPrefs.GetInt("LevelIDCityTT").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("LevelXPCityTT", PlayerPrefs.GetInt("LevelXPCityTT") + CollisionScore3);

					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}

				PlayerPrefs.SetInt("TotalPassedP", PlayerPrefs.GetInt("TotalPassedP") + 1);
				//print("TotalPassed Level:"+PlayerPrefs.GetInt("TotalPassed"));
				//---------------------------------------------------------------------------
				// Player passed one level up

				if (PlayerPrefs.GetInt("LevelIDCityTT") + 1 == PlayerPrefs.GetInt("LevelNumCityTT"))
				{
					PlayerPrefs.SetInt("LevelNumCityTT", PlayerPrefs.GetInt("LevelNumCityTT") + 1);
					PlayerPrefs.SetInt("PassedLevelsP", PlayerPrefs.GetInt("PassedLevelsP") + 1);
				}
				//print("LevelID:" + PlayerPrefs.GetInt("LevelID"));
				//Set the NextLevel ID
				PlayerPrefs.SetInt("LevelIDCityTT", PlayerPrefs.GetInt("LevelIDCityTT") + 1);
				//---------------
				SuccessMenu.transform.DOScale(0, 0.25f)
					.SetEase(Ease.InOutQuart)
					.OnStepComplete(() =>
					{
						SuccessMenu.SetActive(true);
						SuccessMenu.transform.DOScale(1, 0.25f)
						   .SetEase(Ease.InOutQuart);
					});
			}
			else if (SceneManager.GetActiveScene().name == "SwampMap")
			{
				if (CollisionCount == 0)
				{// Score given to player when collision detection is 0
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore0);
					// Show earned score on finish menu
					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore0.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore0.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore0.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore0.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore0.ToString() + "$";
					star3.SetActive(true);
					
					//As.clip = clipSucces;
					//As.Play();
					if (PlayerPrefs.GetInt("StarS" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) < 3)
					{
						PlayerPrefs.SetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), secondTimer);
						if (isDiamondRewarded)
						{
							PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + DiamondReward);
							if (PlayerPrefs.GetString("_language") == "tr")
								DiamondRewardText.text = "Senin icin " + DiamondReward + "x Elmas hediyemiz var!";
							else if (PlayerPrefs.GetString("_language") == "fr")
								DiamondRewardText.text = "Nous avons " + DiamondReward + "x Diamants pour vous!";
							else if (PlayerPrefs.GetString("_language") == "sp")
								DiamondRewardText.text = "Tenemos " + DiamondReward + "x regalos de diamantes para ti";
							else if (PlayerPrefs.GetString("_language") == "de")
								DiamondRewardText.text = "Wir haben " + DiamondReward + "x Diamantgeschenke fur Sie!";
							else
								DiamondRewardText.text = "We have " + DiamondReward + "x Diamond Bonus for you!";
							DiamondRewardMenu.transform.DOScale(0, 0.25f)
							.SetEase(Ease.InOutQuart)
							.OnStepComplete(() =>
							{
								DiamondRewardMenu.SetActive(true);
								DiamondRewardMenu.transform.DOScale(1, 0.25f)
								   .SetEase(Ease.InOutQuart);
							});
						}
					}
					if (PlayerPrefs.GetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) == minuteTimer)
					{

						if (PlayerPrefs.GetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) > secondTimer)
								PlayerPrefs.SetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) > minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("StarS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), 3);	
					PlayerPrefs.SetInt("LevelXPSwamp", PlayerPrefs.GetInt("LevelXPSwamp") + CollisionScore0);
					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}
				if (CollisionCount == 1)
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore1);

					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore1.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore1.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore1.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore1.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore1.ToString() + "$";
					star2.SetActive(true);
					PlayerPrefs.SetInt("StarS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), 2);
					//As.clip = clipSucces;
					//As.Play();
					if (!PlayerPrefs.HasKey("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()))
					{
						PlayerPrefs.SetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), secondTimer);
					}
					if (PlayerPrefs.GetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) == minuteTimer)
					{
						if (PlayerPrefs.GetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) < secondTimer)
								PlayerPrefs.SetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) < minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("LevelXPSwamp", PlayerPrefs.GetInt("LevelXPSwamp") + CollisionScore1);
					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}
				if (CollisionCount == 2)
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore2);

					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore2.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore2.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore2.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore2.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore2.ToString() + "$";
					star1.SetActive(true);
					PlayerPrefs.SetInt("StarS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), 1);
					//As.clip = clipSucces;
					//As.Play();
					if (!PlayerPrefs.HasKey("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()))
					{
						PlayerPrefs.SetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), secondTimer);
					}
					if (PlayerPrefs.GetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) == minuteTimer)
					{
						if (PlayerPrefs.GetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) < secondTimer)
								PlayerPrefs.SetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) < minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("LevelXPSwamp", PlayerPrefs.GetInt("LevelXPSwamp") + CollisionScore2);
					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}

				if (CollisionCount == 3)
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore3);

					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore3.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore3.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore3.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore3.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore3.ToString() + "$";
					//As.clip = clipLost;
					//As.Play();
					if (!PlayerPrefs.HasKey("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()))
					{
						PlayerPrefs.SetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), secondTimer);
					}
					if (PlayerPrefs.GetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) == minuteTimer)
					{
						if (PlayerPrefs.GetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) < secondTimer)
								PlayerPrefs.SetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString()) < minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsS" + PlayerPrefs.GetInt("LevelIDSwamp").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("LevelXPSwamp", PlayerPrefs.GetInt("LevelXPSwamp") + CollisionScore3);

					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}

				PlayerPrefs.SetInt("TotalPassedP", PlayerPrefs.GetInt("TotalPassedP") + 1);
				//print("TotalPassed Level:"+PlayerPrefs.GetInt("TotalPassed"));
				//---------------------------------------------------------------------------
				// Player passed one level up

				if (PlayerPrefs.GetInt("LevelIDSwamp") + 1 == PlayerPrefs.GetInt("LevelNumSwamp"))
				{
					PlayerPrefs.SetInt("LevelNumSwamp", PlayerPrefs.GetInt("LevelNumSwamp") + 1);
					PlayerPrefs.SetInt("PassedLevelsP", PlayerPrefs.GetInt("PassedLevelsP") + 1);
				}
				//print("LevelID:" + PlayerPrefs.GetInt("LevelID"));
				//Set the NextLevel ID
				PlayerPrefs.SetInt("LevelIDSwamp", PlayerPrefs.GetInt("LevelIDSwamp") + 1);
				//---------------
				SuccessMenu.transform.DOScale(0, 0.25f)
					.SetEase(Ease.InOutQuart)
					.OnStepComplete(() =>
					{
						SuccessMenu.SetActive(true);
						SuccessMenu.transform.DOScale(1, 0.25f)
						   .SetEase(Ease.InOutQuart);
					});
			}
			else if (SceneManager.GetActiveScene().name == "SwampMapTT")
			{
				if (CollisionCount == 0)
				{// Score given to player when collision detection is 0
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore0);
					// Show earned score on finish menu
					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore0.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore0.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore0.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore0.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore0.ToString() + "$";
					star3.SetActive(true);
					
					//As.clip = clipSucces;
					//As.Play();
					if (PlayerPrefs.GetInt("StarSTT" + PlayerPrefs.GetInt("LevelIDPrototype").ToString()) < 3)
					{
						PlayerPrefs.SetFloat("MinutMinutesSTTesS" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), secondTimer);
						if (isDiamondRewarded)
						{
							PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + DiamondReward);
							if (PlayerPrefs.GetString("_language") == "tr")
								DiamondRewardText.text = "Senin icin " + DiamondReward + "x Elmas hediyemiz var!";
							else if (PlayerPrefs.GetString("_language") == "fr")
								DiamondRewardText.text = "Nous avons " + DiamondReward + "x Diamants pour vous!";
							else if (PlayerPrefs.GetString("_language") == "sp")
								DiamondRewardText.text = "Tenemos " + DiamondReward + "x regalos de diamantes para ti";
							else if (PlayerPrefs.GetString("_language") == "de")
								DiamondRewardText.text = "Wir haben " + DiamondReward + "x Diamantgeschenke fur Sie!";
							else
								DiamondRewardText.text = "We have " + DiamondReward + "x Diamond Bonus for you!";
							DiamondRewardMenu.transform.DOScale(0, 0.25f)
							.SetEase(Ease.InOutQuart)
							.OnStepComplete(() =>
							{
								DiamondRewardMenu.SetActive(true);
								DiamondRewardMenu.transform.DOScale(1, 0.25f)
								   .SetEase(Ease.InOutQuart);
							});
						}
					}
					if (PlayerPrefs.GetFloat("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) == minuteTimer)
					{

						if (PlayerPrefs.GetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) > secondTimer)
								PlayerPrefs.SetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) > minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("StarSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), 3);
					PlayerPrefs.SetInt("LevelXPSwampTT", PlayerPrefs.GetInt("LevelXPSwampTT") + CollisionScore0);
					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}
				if (CollisionCount == 1)
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore1);

					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore1.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore1.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore1.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore1.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore1.ToString() + "$";
					star2.SetActive(true);
					PlayerPrefs.SetInt("StarSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), 2);
					//As.clip = clipSucces;
					//As.Play();
					if (!PlayerPrefs.HasKey("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()))
					{
						PlayerPrefs.SetFloat("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), secondTimer);
					}
					if (PlayerPrefs.GetFloat("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) == minuteTimer)
					{
						if (PlayerPrefs.GetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) < secondTimer)
								PlayerPrefs.SetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) < minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("LevelXPSwampTT", PlayerPrefs.GetInt("LevelXPSwampTT") + CollisionScore1);
					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}
				if (CollisionCount == 2)
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore2);

					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore2.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore2.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore2.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore2.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore2.ToString() + "$";
					star1.SetActive(true);
					PlayerPrefs.SetInt("StarSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), 1);
					//As.clip = clipSucces;
					//As.Play();
					if (!PlayerPrefs.HasKey("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()))
					{
						PlayerPrefs.SetFloat("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), secondTimer);
					}
					if (PlayerPrefs.GetFloat("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) == minuteTimer)
					{
						if (PlayerPrefs.GetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) < secondTimer)
								PlayerPrefs.SetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) < minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("LevelXPSwampTT", PlayerPrefs.GetInt("LevelXPSwampTT") + CollisionScore2);
					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}

				if (CollisionCount == 3)
				{
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore3);

					if (PlayerPrefs.GetString("_language") == "tr")
						FinishScoreText.text = "Odulunuz: " + CollisionScore3.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "fr")
						FinishScoreText.text = "Ta recompense: " + CollisionScore3.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "sp")
						FinishScoreText.text = "Tu recompensa: " + CollisionScore3.ToString() + "$";
					else if (PlayerPrefs.GetString("_language") == "de")
						FinishScoreText.text = "Deine Belohnung: " + CollisionScore3.ToString() + "$";
					else
						FinishScoreText.text = "Your Reward: " + CollisionScore3.ToString() + "$";
					//As.clip = clipLost;
					//As.Play();
					if (!PlayerPrefs.HasKey("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()))
					{
						PlayerPrefs.SetFloat("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), minuteTimer);
						PlayerPrefs.SetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), secondTimer);
					}
					if (PlayerPrefs.GetFloat("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) == minuteTimer)
					{
						if (PlayerPrefs.GetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) != secondTimer)
						{
							if (PlayerPrefs.GetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) < secondTimer)
								PlayerPrefs.SetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), secondTimer);
						}
					}
					{
						if (PlayerPrefs.GetFloat("MinutesMinutesSTTS" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString()) < minuteTimer)
						{
							PlayerPrefs.SetFloat("MinutesSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), minuteTimer);
							PlayerPrefs.SetFloat("SecondsSTT" + PlayerPrefs.GetInt("LevelIDSwampTT").ToString(), secondTimer);
						}
					}
					PlayerPrefs.SetInt("LevelXPSwampTT", PlayerPrefs.GetInt("LevelXPSwampTT") + CollisionScore3);

					bestTime.text = ReadBestTime();
					currentTime.text = ReadCurrentTIme();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
				}

				PlayerPrefs.SetInt("TotalPassedP", PlayerPrefs.GetInt("TotalPassedP") + 1);
				//print("TotalPassed Level:"+PlayerPrefs.GetInt("TotalPassed"));
				//---------------------------------------------------------------------------
				// Player passed one level up

				if (PlayerPrefs.GetInt("LevelIDSwampTT") + 1 == PlayerPrefs.GetInt("LevelNumSwampTT"))
				{
					PlayerPrefs.SetInt("LevelNumSwampTT", PlayerPrefs.GetInt("LevelNumSwampTT") + 1);
					PlayerPrefs.SetInt("PassedLevelsP", PlayerPrefs.GetInt("PassedLevelsP") + 1);
				}
				//print("LevelID:" + PlayerPrefs.GetInt("LevelID"));
				//Set the NextLevel ID
				PlayerPrefs.SetInt("LevelIDSwampTT", PlayerPrefs.GetInt("LevelIDSwampTT") + 1);
				//---------------
				SuccessMenu.transform.DOScale(0, 0.25f)
					.SetEase(Ease.InOutQuart)
					.OnStepComplete(() =>
					{
						SuccessMenu.SetActive(true);
						SuccessMenu.transform.DOScale(1, 0.25f)
						   .SetEase(Ease.InOutQuart);
					});
			}
		}
	}

	string ReadBestTime()
	{
		float min = 0, secn = 0;

		min = PlayerPrefs.GetFloat("Minutes" + PlayerPrefs.GetInt("LevelID").ToString());
		secn = PlayerPrefs.GetFloat("Seconds" + PlayerPrefs.GetInt("LevelID").ToString());

		string minS, secS;

		minS = min.ToString();
		secS = Mathf.Floor(secn).ToString();

		if (min < 10)
			minS = "0" + min.ToString();

		if (secn < 10)
			secS = "0" + Mathf.Floor(secn).ToString();

		return minS + ":" + secS;

	}

	string ReadCurrentTIme()
	{
		string min;
		string sec;

		if (minuteTimer < 10)
			min = "0" + minuteTimer.ToString();
		else
			min = minuteTimer.ToString();

		if (secondTimer < 10)
			sec = "0" + (Mathf.FloorToInt(secondTimer)).ToString();
		else
			sec = (Mathf.FloorToInt(secondTimer)).ToString();

		return "" + min + ":" + sec;
	}

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

	public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
	{
		if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
		{
			if (CollisionCount == 0)
			{
				PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore0);
				FinishScoreText.text = "Your Reward: " + CollisionScore0.ToString() + "$" + " x2!";
			}
			else if (CollisionCount == 1)
			{
				PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore1);
				FinishScoreText.text = "Your Reward: " + CollisionScore1.ToString() + "$" + " x2!";
			}
			else if (CollisionCount == 2)
			{
				PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore2);
				FinishScoreText.text = "Your Reward: " + CollisionScore2.ToString() + "$" + " x2!";
			}
			else if (CollisionCount == 3)
			{
				PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore3);
				FinishScoreText.text = "Your Reward: " + CollisionScore3.ToString() + "$" + " x2!";
			}
		}else if (placementId == "Interstitial_Android" && showResult == ShowResult.Finished)
		{
			if (Advertisement.IsReady("Banner_Android"))
			{
				Advertisement.Banner.Show("Banner_Android");
				Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
			}
		}
	}
}
