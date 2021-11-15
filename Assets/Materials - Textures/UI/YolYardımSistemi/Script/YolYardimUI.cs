using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YolYardimUI : MonoBehaviour
{
    [SerializeField] private ManStateHandler manStateHandler;
    [SerializeField] private RCC_SceneManager sceneManager;
    [SerializeField] private TotalDamage totalDamage;

    [SerializeField] private Image damageFilling;
    [SerializeField] private Image tireFilling;
    [SerializeField] private Image fuelFilling;


    [SerializeField] private TextMeshProUGUI damagePercentageText;
    [SerializeField] private TextMeshProUGUI tirePercentageText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI gearText;

    public void SetDamageFilling()
    {
        damageFilling.fillAmount = (totalDamage.totalDamage / totalDamage.MaxTotalHealth);
        damagePercentageText.text = ((int)(totalDamage.totalDamage*100 / totalDamage.MaxTotalHealth)).ToString()+"%";
    }
    private void SetTireFilling()
    {
        tireFilling.fillAmount = (manStateHandler.tireHealth / manStateHandler.tireMaxHealth);
        tirePercentageText.text = ((int)(manStateHandler.tireHealth*100 / manStateHandler.tireMaxHealth)).ToString() + "%";
    }
    private void SetFuelFilling()
    {
        fuelFilling.fillAmount = (sceneManager.activePlayerVehicle.fuelTank / sceneManager.activePlayerVehicle.fuelTankCapacity);
    }
    private void SetSpeedText()
    {
        speedText.text = ((int)sceneManager.activePlayerVehicle.speed).ToString()+" KM/H";
    }
    private void SetGearText()
    {
        if (sceneManager.activePlayerVehicle.speed >= 1 && sceneManager.activePlayerVehicle.direction == 1)
            gearText.text = ((int)sceneManager.activePlayerVehicle.currentGear + 1).ToString();
        else if (sceneManager.activePlayerVehicle.speed < 1 && sceneManager.activePlayerVehicle.direction == 1)
            gearText.text = ((int)sceneManager.activePlayerVehicle.currentGear).ToString();
        else if (sceneManager.activePlayerVehicle.direction == -1)
            gearText.text = "R";
    }

    private void Update()
    {
        SetFuelFilling();
        SetTireFilling();
        SetSpeedText();
        SetGearText();
    }

    private void Start()
    {
        sceneManager = FindObjectOfType<RCC_SceneManager>();
    }

}
