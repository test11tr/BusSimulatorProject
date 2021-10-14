using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SeatbeltButtonTrigger : MonoBehaviour
{
    GameObject SeatbeltButton;
    public bool Seatbelt = false;
    string SeatbeltHeader;
    string SeatbeltContent;

    void Start()
    {
        if (PlayerPrefs.GetString("_language") == "tr")
        {
            SeatbeltContent = "Artik motoru calistirabilirsiniz.";
            SeatbeltHeader = "Emniyet Kemeri Takildi!";
        }else if (PlayerPrefs.GetString("_language") == "fr")
        {
            SeatbeltContent = "Vous pouvez maintenant demarrer le moteur.";
            SeatbeltHeader = "Ceinture de s�curit� attach�e !";
        }else if (PlayerPrefs.GetString("_language") == "sp")
        {
            SeatbeltContent = "Ahora puede arrancar el motor.";
            SeatbeltHeader = "Cinturon de seguridad abrochado!";
        }else if (PlayerPrefs.GetString("_language") == "de")
        {
            SeatbeltContent = "Jetzt k�nnen Sie den Motor starten.";
            SeatbeltHeader = "Sicherheitsgurt angelegt!";
        }
        else
        {
            SeatbeltContent = "Now you can start the engine.";
            SeatbeltHeader = "Seat belt fastened!";
        }
    }
    public void SeatbeltFunction()
    {
        Seatbelt = true;
        SeatbeltButton = GameObject.Find("SeatbeltToggle");
        //SeatbeltButton.SetActive(false);
        TooltipSystem.Show(SeatbeltContent, SeatbeltHeader);
        SeatbeltButton.transform.DOScale(0, 0.5f)
            .SetEase(Ease.InOutElastic);
    }
}
