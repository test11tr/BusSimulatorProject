using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Advertisements;
public class MenuHandler : MonoBehaviour, IUnityAdsListener
{
	public Slider volumeSlider;



    string gameId = "4205809";

    private void Start()
    {
		Advertisement.Initialize(gameId);
		Advertisement.AddListener(this);
		LoadVolume();
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
	public void DiscordButton()
	{
		Application.OpenURL("https://discord.gg/tZNUeQdAaM");
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

	private void SaveVolume()
	{
		PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
		PlayBannerAd();
	}

	public void PlayBannerAd()
	{
		if(PlayerPrefs.GetInt("NoAds") == 0)
        {
			if (Advertisement.IsReady("Banner_Android"))
			{
				Advertisement.Banner.Show("Banner_Android");
				Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
			}
		}
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
		Advertisement.Banner.Hide();
	}

    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        throw new System.NotImplementedException();
    }
}