using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class SuccessMenu : MonoBehaviour
{

    string gameId = "4205809";


    public GameObject exitButton;
    public GameObject nextButton;
    public GameObject adsButton;
    public void ExitButton()
    {
        //LoadScreen
        SceneManager.LoadScene("MainMenu");
    }
    public void NextButton()
    {
        //print("Next");
        //LoadScreen Koy
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AdPlayed()
    {
        //print("AdsToScreen");
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
}
