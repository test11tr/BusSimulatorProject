using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifications : MonoBehaviour
{
    [SerializeField] private GameObject[] notification;

    [SerializeField] private float gapBetweenNotifications;
    private int notificationNumber = 0;


    private int[] notiNumberInPlace = new int[7];

    private void Start()
    {
        GameEvents.current.onAccident += AccidentNotification;
        GameEvents.current.onEngineMalfunction += EngineMalfunctionNotification;
        GameEvents.current.onHeadlightViolation += HeadlightNotification;
        GameEvents.current.onLaneViolation += LaneNotification;
        GameEvents.current.onRedLightViolation += RedLightNotification;
        GameEvents.current.onSpeedLimitViolation += SpeedLimitNotification;
        GameEvents.current.onTireLife += TireLifeNotification;

        GameEvents.current.onAccidentDismiss += AccidentDismiss;
        GameEvents.current.onEngineMalDismiss += EngineMalDismiss;
        GameEvents.current.onHeadlightDismiss += HeadlightDismiss;
        GameEvents.current.onLaneDismiss += LaneDismiss;
        GameEvents.current.onRedLightDismiss += RedLightDismiss;
        GameEvents.current.onSpeedLimitDismiss += SpeedLimitDismiss;
        GameEvents.current.onTireLifeDismiss += TireLifeDismiss;
    }

    private void AccidentNotification()
    {
        LeanTween.moveY(notification[0].GetComponent<RectTransform>(), (gapBetweenNotifications*notificationNumber), 0f);
        notiNumberInPlace[0] = notificationNumber;
        notificationNumber++;
        LeanTween.moveX(notification[0].GetComponent<RectTransform>(), -1050, 0.4f).setEaseOutQuad();
    }
    private void AccidentDismiss()
    {
        notificationNumber--;
        RepositionNotifications(notiNumberInPlace[0]);
        LeanTween.moveX(notification[0].GetComponent<RectTransform>(), -500, 0.4f).setEaseOutQuad();
    }
    private void EngineMalfunctionNotification()
    {
        LeanTween.moveY(notification[1].GetComponent<RectTransform>(), (gapBetweenNotifications * notificationNumber), 0f);
        notiNumberInPlace[1] = notificationNumber;
        notificationNumber++;
        LeanTween.moveX(notification[1].GetComponent<RectTransform>(), -1050, 0.4f).setEaseOutQuad();
    }
    private void EngineMalDismiss()
    {
        notificationNumber--;
        RepositionNotifications(notiNumberInPlace[1]);
        LeanTween.moveX(notification[1].GetComponent<RectTransform>(), -500, 0.4f).setEaseOutQuad();
    }

    private void HeadlightNotification()
    {
        LeanTween.moveY(notification[2].GetComponent<RectTransform>(), (gapBetweenNotifications * notificationNumber), 0f);
        notiNumberInPlace[2] = notificationNumber;
        notificationNumber++;
        LeanTween.moveX(notification[2].GetComponent<RectTransform>(), -1050, 0.4f).setEaseOutQuad();
    }
    private void HeadlightDismiss()
    {
        notificationNumber--;
        RepositionNotifications(notiNumberInPlace[2]);
        LeanTween.moveX(notification[2].GetComponent<RectTransform>(), -500, 0.4f).setEaseOutQuad();
    }
    private void LaneNotification()
    {
        LeanTween.moveY(notification[3].GetComponent<RectTransform>(), (gapBetweenNotifications * notificationNumber), 0f);
        notiNumberInPlace[3] = notificationNumber;
        notificationNumber++;
        LeanTween.moveX(notification[3].GetComponent<RectTransform>(), -1050, 0.4f).setEaseOutQuad();
    }
    private void LaneDismiss()
    {
        notificationNumber--;
        RepositionNotifications(notiNumberInPlace[3]);
        LeanTween.moveX(notification[3].GetComponent<RectTransform>(), -500, 0.4f).setEaseOutQuad();
    }
    private void RedLightNotification()
    {
        LeanTween.moveY(notification[4].GetComponent<RectTransform>(), (gapBetweenNotifications * notificationNumber), 0f);
        notiNumberInPlace[4] = notificationNumber;
        notificationNumber++;
        LeanTween.moveX(notification[4].GetComponent<RectTransform>(), -1050, 0.4f).setEaseOutQuad();
    }
    private void RedLightDismiss()
    {
        notificationNumber--;
        RepositionNotifications(notiNumberInPlace[4]);
        LeanTween.moveX(notification[4].GetComponent<RectTransform>(), -500, 0.4f).setEaseOutQuad();
    }
    private void SpeedLimitNotification()
    {
        LeanTween.moveY(notification[5].GetComponent<RectTransform>(), (gapBetweenNotifications * notificationNumber), 0f);
        notiNumberInPlace[5] = notificationNumber;
        notificationNumber++;
        LeanTween.moveX(notification[5].GetComponent<RectTransform>(), -1050, 0.4f).setEaseOutQuad();
    }
    private void SpeedLimitDismiss()
    {
        notificationNumber--;
        RepositionNotifications(notiNumberInPlace[5]);
        LeanTween.moveX(notification[5].GetComponent<RectTransform>(), -500, 0.4f).setEaseOutQuad();
    }
    private void TireLifeNotification()
    {
        LeanTween.moveY(notification[6].GetComponent<RectTransform>(), (gapBetweenNotifications * notificationNumber), 0f);
        notiNumberInPlace[6] = notificationNumber;
        notificationNumber++;
        LeanTween.moveX(notification[6].GetComponent<RectTransform>(), -1050, 0.4f).setEaseOutQuad();
    }
    private void TireLifeDismiss()
    {
        notificationNumber--;
        RepositionNotifications(notiNumberInPlace[6]);
        LeanTween.moveX(notification[6].GetComponent<RectTransform>(), -500, 0.4f).setEaseOutQuad();
    }

    private void RepositionNotifications(int itself)
    {
        for(int i = 0; i < notification.Length; i++)
        {
            if(i != itself)
            {
                notiNumberInPlace[i]--;
            }
            if (itself <= notiNumberInPlace[i])
            {
                LeanTween.moveY(notification[i].GetComponent<RectTransform>(), (gapBetweenNotifications * notiNumberInPlace[i]), 0.5f);
            }

        }
    }
}
