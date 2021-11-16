using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }
    public event Action onAccident;
    public event Action onEngineMalfunction;
    public event Action onHeadlightViolation;
    public event Action onLaneViolation;
    public event Action onRedLightViolation;
    public event Action onSpeedLimitViolation;
    public event Action onTireLife;

    public event Action onAccidentDismiss;
    public event Action onEngineMalDismiss;
    public event Action onHeadlightDismiss;
    public event Action onLaneDismiss;
    public event Action onRedLightDismiss;
    public event Action onSpeedLimitDismiss;
    public event Action onTireLifeDismiss;

    public void AccidentNotification()
    {
        if(onAccident != null)
        {
            onAccident();
        }
    }
    public void EngineMalfunctionNotification()
    {
        if (onEngineMalfunction != null)
        {
            onEngineMalfunction();
        }
    }
    public void HeadlightNotification()
    {
        if (onHeadlightViolation != null)
        {
            onHeadlightViolation();
        }
    }
    public void LaneNotification()
    {
        if (onLaneViolation != null)
        {
            onLaneViolation();
        }
    }
    public void RedLightNotification()
    {
        if (onRedLightViolation != null)
        {
            onRedLightViolation();
        }
    }
    public void SpeedLimitNotification()
    {
        if (onSpeedLimitViolation != null)
        {
            onSpeedLimitViolation();
        }
    }
    public void TireLifeNotification()
    {
        if (onTireLife != null)
        {
            onTireLife();
        }
    }

    public void AccidentDismiss()
    {
        if (onAccidentDismiss != null)
        {
            onAccidentDismiss();
        }
    }
    public void EngineMalDismiss()
    {
        if (onEngineMalDismiss != null)
        {
            onEngineMalDismiss();
        }
    }
    public void HeadlightDismiss()
    {
        if (onHeadlightDismiss != null)
        {
            onHeadlightDismiss();
        }
    }

    public void LaneDismiss()
    {
        if (onLaneDismiss != null)
        {
            onLaneDismiss();
        }
    }
    public void RedlightDismiss()
    {
        if (onRedLightDismiss != null)
        {
            onRedLightDismiss();
        }
    }
    public void SpeedLimitDismiss()
    {
        if (onSpeedLimitDismiss != null)
        {
            onSpeedLimitDismiss();
        }
    }
    public void TireLifeDismiss()
    {
        if (onTireLifeDismiss != null)
        {
            onTireLifeDismiss();
        }
    }


}
