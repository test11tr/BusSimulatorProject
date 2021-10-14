using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EngineButton : MonoBehaviour
{
    GameObject Button;
    string SeatbeltErrorContent;
    string SeatbeltErrorHeader;
    public SeatbeltButtonTrigger SButton;
    public RCC_SceneManager sceneManager;
    void Start()
    {
        if (PlayerPrefs.GetString("_language") == "tr")
        {
            SeatbeltErrorContent = "Once emniyet kemerinizi takmaniz lazim!";
            SeatbeltErrorHeader = "Emniyet Kemeri Takili Degil";
        }
        else if (PlayerPrefs.GetString("_language") == "fr")
        {
            SeatbeltErrorContent = "Vous devez d abord attacher votre ceinture de securite!";
            SeatbeltErrorHeader = "Ceinture de securite non attachee";
        }
        else if (PlayerPrefs.GetString("_language") == "sp")
        {
            SeatbeltErrorContent = "Primero debe abrocharse el cinturon de seguridad!";
            SeatbeltErrorHeader = "Cinturon de seguridad no abrochado";
        }
        else if (PlayerPrefs.GetString("_language") == "de")
        {
            SeatbeltErrorContent = "Zuerst mussen Sie Ihren Sicherheitsgurt anlegen!";
            SeatbeltErrorHeader = "Sicherheitsgurt nicht angelegt";
        }
        else
        {
            SeatbeltErrorContent = "First you need to fasten your seat belt!";
            SeatbeltErrorHeader = "Seat Belt Not Fastened!";
        }
    }
    public void TurnEngineButtonOff()
    {
        if (SButton.Seatbelt)
        {
            Button = GameObject.Find("Start/Kill Engine Button ");
            //Button.SetActive(false);
            Button.transform.DOScale(0, 0.5f)
                .SetEase(Ease.InOutElastic)
                .OnStepComplete(() =>
                 {
                     TooltipSystem.Hide();
                 });
            //print(playerSpawner.PlayerVehicle);
            RCC.SetEngine(sceneManager.activePlayerVehicle, true);
        }
        else
        {
            TooltipSystem.Show(SeatbeltErrorContent, SeatbeltErrorHeader);
        } 
    }
}
