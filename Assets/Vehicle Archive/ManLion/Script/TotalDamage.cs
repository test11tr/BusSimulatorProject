using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalDamage : MonoBehaviour
{
    public float damageMultiplier;

    public float frontDamage { get; private set; }
    public float rearDamage { get; private set; }
    public float leftDamage { get; private set; }
    public float rightDamage { get; private set; }
    public float totalDamage { get; private set; }

    public float MaxTotalHealth;
    public float MaxPartialHealth;

    [SerializeField] private YolYardimUI yolYardim;


    private void Start()
    {
        frontDamage = PlayerPrefs.GetFloat("FrontDamage");
        rearDamage = PlayerPrefs.GetFloat("RearDamage");
        leftDamage = PlayerPrefs.GetFloat("LeftDamage");
        rightDamage = PlayerPrefs.GetFloat("RightDamage");
        totalDamage = PlayerPrefs.GetFloat("TotalDamage");
        yolYardim.SetDamageFilling();
    }


    public void FrontDamageSet(float addedDamage)
    {
        frontDamage += addedDamage;
        totalDamage += addedDamage;


        GameEvents.current.EngineMalfunctionNotification();
        Debug.Log("FRONT DAMAGE IS = " + frontDamage + " AND TOTAL DAMAGE IS = " + totalDamage);

        PlayerPrefs.SetFloat("FrontDamage",frontDamage);
        PlayerPrefs.SetFloat("TotalDamage", totalDamage);
        IsCarBusted();
    }
    public void RearDamageSet(float addedDamage)
    {
        rearDamage += addedDamage;
        totalDamage += addedDamage;
        Debug.Log("REAR DAMAGE IS = " + rearDamage + " AND TOTAL DAMAGE IS = " + totalDamage);

        PlayerPrefs.SetFloat("RearDamage", rearDamage);
        PlayerPrefs.SetFloat("TotalDamage", totalDamage);
        IsCarBusted();
    }
    public void LeftDamageSet(float addedDamage)
    {
        leftDamage += addedDamage;
        totalDamage += addedDamage;
        Debug.Log("LEFT DAMAGE IS = " + leftDamage + " AND TOTAL DAMAGE IS = " + totalDamage);

        PlayerPrefs.SetFloat("LeftDamage", leftDamage);
        PlayerPrefs.SetFloat("TotalDamage", totalDamage);
        IsCarBusted();
    }
    public void RightDamageSet(float addedDamage)
    {
        rightDamage += addedDamage;
        totalDamage += addedDamage;
        Debug.Log("RIGHT DAMAGE IS = " + rightDamage + " AND TOTAL DAMAGE IS = " + totalDamage);

        PlayerPrefs.SetFloat("RightDamage", rightDamage);
        PlayerPrefs.SetFloat("TotalDamage", totalDamage);
        IsCarBusted();
    }

    private void IsCarBusted()
    {   
        yolYardim.SetDamageFilling();
        if(rightDamage > MaxPartialHealth || leftDamage > MaxPartialHealth || rearDamage > MaxPartialHealth || frontDamage > MaxPartialHealth || totalDamage > MaxTotalHealth)
        {
            Debug.Log("CAR IS BUSTED AND NEEDS REPAIR");
            RepairCar();
            Debug.Log("CAR IS REPAIRED");
        }
    }
    public void RepairCar()
    {
        PlayerPrefs.SetFloat("FrontDamage",0);
        PlayerPrefs.SetFloat("RearDamage",0);
        PlayerPrefs.SetFloat("LeftDamage",0);
        PlayerPrefs.SetFloat("RightDamage",0);
        PlayerPrefs.SetFloat("TotalDamage",0);
        frontDamage = 0;
        rearDamage = 0;
        leftDamage = 0;
        rightDamage = 0;
        totalDamage = 0;
    }
}

