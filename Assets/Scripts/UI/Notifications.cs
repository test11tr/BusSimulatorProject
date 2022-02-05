using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifications : MonoBehaviour
{
    [SerializeField] private GameObject[] notification;

    [SerializeField] private float gapBetweenNotifications;

    private int notificationNumber = 0;


    private int[] notiNumberInPlace = new int[7];
    private bool[] notiIsActive = new bool[7];

    [SerializeField] private int showPosX;
    [SerializeField] private int dismissPosX;


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

    private void NotificationActivate(int notiIndex)
    {
        if (!notiIsActive[notiIndex])
        {
            Debug.Log("activate " + notiNumberInPlace[notiIndex]);
            notiIsActive[notiIndex] = true;

            LeanTween.moveY(notification[notiIndex].GetComponent<RectTransform>(), (gapBetweenNotifications * notificationNumber), 0f);
            LeanTween.moveX(notification[notiIndex].GetComponent<RectTransform>(), showPosX, 0.4f).setEaseOutQuad();

            notiNumberInPlace[notiIndex] = notificationNumber;
            notificationNumber++;

        }
    }
    private void NotificationDismiss(int notiIndex)
    {
        if (notiIsActive[notiIndex])
        {
            Debug.Log("deactivate " + notiNumberInPlace[notiIndex]);
            notiIsActive[notiIndex] = false;

            RepositionNotifications(notiNumberInPlace[notiIndex]);
            LeanTween.moveX(notification[notiIndex].GetComponent<RectTransform>(), dismissPosX, 0.4f).setEaseOutQuad();

            notificationNumber--;

        }
    }

    private void RepositionNotifications(int itself)
    {
        for (int i = 0; i < notification.Length; i++)
        {
            if (i != itself)
            {

            }
            if (itself <= notiNumberInPlace[i])
            {
                notiNumberInPlace[i]--;
                if (notiNumberInPlace[i] + 1 != itself)
                {
                    LeanTween.moveY(notification[i].GetComponent<RectTransform>(), (gapBetweenNotifications * notiNumberInPlace[i]), 0.5f);
                }

            }
        }
    }
    #region NotificationsList
    private void AccidentNotification()
    {

        NotificationActivate(0);
    }
    private void AccidentDismiss()
    {
        NotificationDismiss(0);

    }
    private void EngineMalfunctionNotification()
    {
        NotificationActivate(1);

    }
    private void EngineMalDismiss()
    {
        NotificationDismiss(1);

    }

    private void HeadlightNotification()
    {
        NotificationActivate(2);

    }
    private void HeadlightDismiss()
    {
        NotificationDismiss(2);

    }
    private void LaneNotification()
    {
        NotificationActivate(3);

    }
    private void LaneDismiss()
    {
        NotificationDismiss(3);

    }
    private void RedLightNotification()
    {
        NotificationActivate(4);

    }
    private void RedLightDismiss()
    {
        NotificationDismiss(4);

    }
    private void SpeedLimitNotification()
    {
        NotificationActivate(5);

    }
    private void SpeedLimitDismiss()
    {
        NotificationDismiss(5);

    }
    private void TireLifeNotification()
    {
        NotificationActivate(6);

    }
    private void TireLifeDismiss()
    {
        NotificationDismiss(6);

    }
    #endregion
}
