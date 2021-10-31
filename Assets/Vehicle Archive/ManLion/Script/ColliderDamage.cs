using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDamage : MonoBehaviour
{
    public float partDamage;

    [SerializeField] private TotalDamage totalDamage;

    [SerializeField] private int damagedPart; // 0 = front,1 = rear,2 = left,3 = right 

    [SerializeField] private RCC_SceneManager sceneManager;
    private void OnTriggerEnter()
    {
        if(sceneManager.activePlayerVehicle.speed > 8)
        {
            switch (damagedPart)
            {
                case 0:
                    Debug.Log("FRONT HIT!!!");
                    if(totalDamage.damageMultiplier*sceneManager.activePlayerVehicle.speed < 100)
                    {
                        totalDamage.FrontDamageSet(totalDamage.damageMultiplier * sceneManager.activePlayerVehicle.speed);
                    }
                    else
                    {
                        totalDamage.FrontDamageSet(100);
                    }
                    break;
                case 1:
                    Debug.Log("REAR HIT!!!");
                    if (totalDamage.damageMultiplier * sceneManager.activePlayerVehicle.speed < 100)
                    {
                        totalDamage.RearDamageSet(totalDamage.damageMultiplier * sceneManager.activePlayerVehicle.speed);
                    }
                    else
                    {
                        totalDamage.RearDamageSet(100);
                    }
                    break;
                case 2:
                    Debug.Log("LEFT HIT!!!");
                    if (totalDamage.damageMultiplier * sceneManager.activePlayerVehicle.speed < 100)
                    {
                        totalDamage.LeftDamageSet(totalDamage.damageMultiplier * sceneManager.activePlayerVehicle.speed);
                    }
                    else
                    {
                        totalDamage.LeftDamageSet(100);
                    }
                    break;
                case 3:
                    Debug.Log("RIGHT HIT!!!");
                    if (totalDamage.damageMultiplier * sceneManager.activePlayerVehicle.speed < 100)
                    {
                        totalDamage.RightDamageSet(totalDamage.damageMultiplier * sceneManager.activePlayerVehicle.speed);
                    }
                    else
                    {
                        totalDamage.RightDamageSet(100);
                    }
                    break;
            }
        }
    }

}
