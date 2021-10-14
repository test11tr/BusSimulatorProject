using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

	// Array of locks
	public GameObject[] Locks;

	// Temp
	int temp;

	// Next menu for activat it
	public GameObject currentMenu, nextMenu;

	public GameObject[] star1Level, star2Level, star3Level,starsMain;

	public Text[] bestTime;

	public GameObject selectDialog;

	public GameObject loading;

	public bool inGarage;
	public string levelName = "LevelNameHandler";

	void Start()
	{
		if (levelName == "PrototypeScene")
		{
			//Level  num   is  :   3
			temp = PlayerPrefs.GetInt("LevelNumPrototype");
			for (int a = 0; a <= temp; a++)
			{
				if (temp > a)
					Locks[a].SetActive(false);
			}

			for (int aa = 0; aa < bestTime.Length; aa++)
			{

				float min = PlayerPrefs.GetFloat("MinutesP" + aa.ToString());
				float secn = PlayerPrefs.GetFloat("SecondsP" + aa.ToString());

				string minS, secS;

				minS = min.ToString();
				secS = Mathf.Floor(secn).ToString();

				if (min < 10)
					minS = "0" + min.ToString();

				if (secn < 10)
					secS = "0" + Mathf.Floor(secn).ToString();


				bestTime[aa].text = (minS + ":" + secS)
					.ToString();



				if (PlayerPrefs.GetInt("StarP" + aa.ToString()) == 3)
				{
					star1Level[aa].SetActive(true);
					star2Level[aa].SetActive(true);
					star3Level[aa].SetActive(true);
				}
				if (PlayerPrefs.GetInt("StarP" + aa.ToString()) == 2)
				{
					star1Level[aa].SetActive(true);
					star2Level[aa].SetActive(true);
					star3Level[aa].SetActive(false);
				}
				if (PlayerPrefs.GetInt("StarP" + aa.ToString()) == 1)
				{
					star1Level[aa].SetActive(true);
					star2Level[aa].SetActive(false);
					star3Level[aa].SetActive(false);
				}
				if (PlayerPrefs.GetInt("StarP" + aa.ToString()) == 0)
				{
					starsMain[aa].SetActive(false);
					star1Level[aa].SetActive(false);
					star2Level[aa].SetActive(false);
					star3Level[aa].SetActive(false);
				}
			}
		}
		else if (levelName == "CityScene")
		{
			//Level  num   is  :   3
			temp = PlayerPrefs.GetInt("LevelNumCity");
			for (int a = 0; a <= temp; a++)
			{
				if (temp > a)
					Locks[a].SetActive(false);
			}

			for (int aa = 0; aa < bestTime.Length; aa++)
			{

				float min = PlayerPrefs.GetFloat("MinutesC" + aa.ToString());
				float secn = PlayerPrefs.GetFloat("SecondsC" + aa.ToString());

				string minS, secS;

				minS = min.ToString();
				secS = Mathf.Floor(secn).ToString();

				if (min < 10)
					minS = "0" + min.ToString();

				if (secn < 10)
					secS = "0" + Mathf.Floor(secn).ToString();


				bestTime[aa].text = (minS + ":" + secS)
					.ToString();



				if (PlayerPrefs.GetInt("StarC" + aa.ToString()) == 3)
				{
					star1Level[aa].SetActive(true);
					star2Level[aa].SetActive(true);
					star3Level[aa].SetActive(true);
				}
				if (PlayerPrefs.GetInt("StarC" + aa.ToString()) == 2)
				{
					star1Level[aa].SetActive(true);
					star2Level[aa].SetActive(true);
					star3Level[aa].SetActive(false);
				}
				if (PlayerPrefs.GetInt("StarC" + aa.ToString()) == 1)
				{
					star1Level[aa].SetActive(true);
					star2Level[aa].SetActive(false);
					star3Level[aa].SetActive(false);
				}
				if (PlayerPrefs.GetInt("StarC" + aa.ToString()) == 0)
				{
					starsMain[aa].SetActive(false);
					star1Level[aa].SetActive(false);
					star2Level[aa].SetActive(false);
					star3Level[aa].SetActive(false);
				}
			}
		}
		else if (levelName == "CitySceneTT")
		{
			//Level  num   is  :   3
			temp = PlayerPrefs.GetInt("LevelNumCityTT");
			for (int a = 0; a <= temp; a++)
			{
				if (temp > a)
					Locks[a].SetActive(false);
			}

			for (int aa = 0; aa < bestTime.Length; aa++)
			{

				float min = PlayerPrefs.GetFloat("MinutesCTT" + aa.ToString());
				float secn = PlayerPrefs.GetFloat("SecondsCTT" + aa.ToString());

				string minS, secS;

				minS = min.ToString();
				secS = Mathf.Floor(secn).ToString();

				if (min < 10)
					minS = "0" + min.ToString();

				if (secn < 10)
					secS = "0" + Mathf.Floor(secn).ToString();


				bestTime[aa].text = (minS + ":" + secS)
					.ToString();



				if (PlayerPrefs.GetInt("StarCTT" + aa.ToString()) == 3)
				{
					star1Level[aa].SetActive(true);
					star2Level[aa].SetActive(true);
					star3Level[aa].SetActive(true);
				}
				if (PlayerPrefs.GetInt("StarCTT" + aa.ToString()) == 2)
				{
					star1Level[aa].SetActive(true);
					star2Level[aa].SetActive(true);
					star3Level[aa].SetActive(false);
				}
				if (PlayerPrefs.GetInt("StarCTT" + aa.ToString()) == 1)
				{
					star1Level[aa].SetActive(true);
					star2Level[aa].SetActive(false);
					star3Level[aa].SetActive(false);
				}
				if (PlayerPrefs.GetInt("StarCTT" + aa.ToString()) == 0)
				{
					starsMain[aa].SetActive(false);
					star1Level[aa].SetActive(false);
					star2Level[aa].SetActive(false);
					star3Level[aa].SetActive(false);
				}
			}
		}
		else if (levelName == "SwampMap")
		{
			//Level  num   is  :   3
			temp = PlayerPrefs.GetInt("LevelNumSwamp");
			for (int a = 0; a <= temp; a++)
			{
				if (temp > a)
					Locks[a].SetActive(false);
			}

			for (int aa = 0; aa < bestTime.Length; aa++)
			{

				float min = PlayerPrefs.GetFloat("MinutesS" + aa.ToString());
				float secn = PlayerPrefs.GetFloat("SecondsS" + aa.ToString());

				string minS, secS;

				minS = min.ToString();
				secS = Mathf.Floor(secn).ToString();

				if (min < 10)
					minS = "0" + min.ToString();

				if (secn < 10)
					secS = "0" + Mathf.Floor(secn).ToString();


				bestTime[aa].text = (minS + ":" + secS)
					.ToString();



				if (PlayerPrefs.GetInt("StarS" + aa.ToString()) == 3)
				{
					star1Level[aa].SetActive(true);
					star2Level[aa].SetActive(true);
					star3Level[aa].SetActive(true);
				}
				if (PlayerPrefs.GetInt("StarS" + aa.ToString()) == 2)
				{
					star1Level[aa].SetActive(true);
					star2Level[aa].SetActive(true);
					star3Level[aa].SetActive(false);
				}
				if (PlayerPrefs.GetInt("StarS" + aa.ToString()) == 1)
				{
					star1Level[aa].SetActive(true);
					star2Level[aa].SetActive(false);
					star3Level[aa].SetActive(false);
				}
				if (PlayerPrefs.GetInt("StarS" + aa.ToString()) == 0)
				{
					starsMain[aa].SetActive(false);
					star1Level[aa].SetActive(false);
					star2Level[aa].SetActive(false);
					star3Level[aa].SetActive(false);
				}
			}
		}
		else if (levelName == "SwampMapTT")
		{
			//Level  num   is  :   3
			temp = PlayerPrefs.GetInt("LevelNumSwampTT");
			for (int a = 0; a <= temp; a++)
			{
				if (temp > a)
					Locks[a].SetActive(false);
			}

			for (int aa = 0; aa < bestTime.Length; aa++)
			{

				float min = PlayerPrefs.GetFloat("MinutesSTT" + aa.ToString());
				float secn = PlayerPrefs.GetFloat("SecondsSTT" + aa.ToString());

				string minS, secS;

				minS = min.ToString();
				secS = Mathf.Floor(secn).ToString();

				if (min < 10)
					minS = "0" + min.ToString();

				if (secn < 10)
					secS = "0" + Mathf.Floor(secn).ToString();


				bestTime[aa].text = (minS + ":" + secS)
					.ToString();



				if (PlayerPrefs.GetInt("StarSTT" + aa.ToString()) == 3)
				{
					star1Level[aa].SetActive(true);
					star2Level[aa].SetActive(true);
					star3Level[aa].SetActive(true);
				}
				if (PlayerPrefs.GetInt("StarSTT" + aa.ToString()) == 2)
				{
					star1Level[aa].SetActive(true);
					star2Level[aa].SetActive(true);
					star3Level[aa].SetActive(false);
				}
				if (PlayerPrefs.GetInt("StarSTT" + aa.ToString()) == 1)
				{
					star1Level[aa].SetActive(true);
					star2Level[aa].SetActive(false);
					star3Level[aa].SetActive(false);
				}
				if (PlayerPrefs.GetInt("StarSTT" + aa.ToString()) == 0)
				{
					starsMain[aa].SetActive(false);
					star1Level[aa].SetActive(false);
					star2Level[aa].SetActive(false);
					star3Level[aa].SetActive(false);
				}
			}
		}
	}

	public void SelectLevel(int id)
	{
		
		if (id < temp)
		{
			tempID = id;

			selectDialog.SetActive(true);
		}

	}

	int tempID;

	public void SelectLevelNow()
	{
		//if (loading)
		//loading.SetActive(true);

		//if (!inGarage)
		//GetComponentInParent<PauseMen>().Resume();

		if (levelName == "PrototypeScene")
		{
			PlayerPrefs.SetInt("LevelIDPrototype", tempID);
			if (inGarage)
				SceneManager.LoadScene(levelName);
			else
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		else if (levelName == "CityScene")
		{
			PlayerPrefs.SetInt("LevelIDCity", tempID);
			if (inGarage)
				SceneManager.LoadScene(levelName);
			else
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		else if (levelName == "CitySceneTT")
		{
			PlayerPrefs.SetInt("LevelIDCityTT", tempID);
			if (inGarage)
				SceneManager.LoadScene(levelName);
			else
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		else if (levelName == "SwampMap")
		{
			PlayerPrefs.SetInt("LevelIDSwamp", tempID);
			if (inGarage)
				SceneManager.LoadScene(levelName);
			else
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		else if (levelName == "SwampMapTT")
		{
			PlayerPrefs.SetInt("LevelIDSwampTT", tempID);
			if (inGarage)
				SceneManager.LoadScene(levelName);
			else
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}


	}

}
