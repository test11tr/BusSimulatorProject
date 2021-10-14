using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class PlayerSpawner : MonoBehaviour
{
    int selectedCarIndex = 0;
    public GameObject SelectButton;
    public GameObject BuyButton;
    public GameObject BuyButtonDiamond;
    public GameObject BuyButtonDiamond2;
    public GameObject VehicleBuyMenu;
    public GameObject VehicleBuyMenuDiamond;
    public GameObject VehicleBuySuccess;
    public GameObject VehicleBuyFail;
    public Text VehiclePriceText;
    public TMP_Text ClassTextAsset;
    public GameObject PriceDiv;
    public GameObject PricecAsDiamondDiv;
    public GameObject CoinImg;
    public GameObject DiamondImg;
    public TMP_Text PriceText;
    public TMP_Text PriceTextasDiamond;
    private List<RCC_CarControllerV3> _spawnedVehicles = new List<RCC_CarControllerV3>();
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            for (int i = 0; i < RCC_DemoVehicles.Instance.vehicles.Length; i++)
            {
                RCC_CarControllerV3 spawnedVehicle = RCC.SpawnRCC(RCC_DemoVehicles.Instance.vehicles[i], transform.position, transform.rotation, false, false, false);
                spawnedVehicle.gameObject.SetActive(false);
                _spawnedVehicles.Add(spawnedVehicle);
            }
            int selectedIndex = PlayerPrefs.GetInt("SelectedRCCVehicle");
            _spawnedVehicles[selectedIndex].gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "TrafficRiderTT")
        {
            int selectedIndex = PlayerPrefs.GetInt("SelectedRCCVehicle");
            RCC_CarControllerV3 PlayerVehicle = RCC.SpawnRCC(RCC_DemoVehicles.Instance.vehicles[selectedIndex], transform.position, transform.rotation, true, true, true);
        }
        else
        {
            int selectedIndex = PlayerPrefs.GetInt("SelectedRCCVehicle");
            RCC_CarControllerV3 PlayerVehicle = RCC.SpawnRCC(RCC_DemoVehicles.Instance.vehicles[selectedIndex], transform.position, transform.rotation, true, true, false);
        }
    }
    public void NextVehicle()
    {
        selectedCarIndex++;
        if (selectedCarIndex > _spawnedVehicles.Count - 1)
            selectedCarIndex = 0;
        SpawnVehicle();
    }
    public void PreviousVehicle()
    {
        selectedCarIndex--;
        if (selectedCarIndex < 0)
            selectedCarIndex = _spawnedVehicles.Count - 1;
        SpawnVehicle();
    }
    public void SpawnVehicle()
    {
        for (int i = 0; i < _spawnedVehicles.Count; i++)
            _spawnedVehicles[i].gameObject.SetActive(false);
            _spawnedVehicles[selectedCarIndex].gameObject.SetActive(true);

        if (selectedCarIndex == 0)
        {
            ClassTextAsset.text = "CLASSIC";
            if (PlayerPrefs.GetInt("Veh0Owned") == 1)
            {
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                //print("Vehicle is Yours");
            }
            else
            {
                PricecAsDiamondDiv.SetActive(true);
                SelectButton.SetActive(false);
                BuyButtonDiamond.SetActive(true);
                BuyButton.SetActive(true);
                PriceDiv.SetActive(true);
                CoinImg.SetActive(true);
                DiamondImg.SetActive(false);
                PriceText.alignment = TextAlignmentOptions.Center;
                PriceText.text = PlayerPrefs.GetInt("Veh0Price") + "<color=lime><i>$</i></color>";
                //print("Vehicle is not yours.");
            }
        } 
        
        else if (selectedCarIndex == 1)
        {
            ClassTextAsset.text = "OFFROAD";
            if (PlayerPrefs.GetInt("Veh1Owned") == 1)
            {
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                //print("Vehicle is Yours");
            }
            else
            {
                BuyButtonDiamond2.SetActive(false);
                BuyButtonDiamond.SetActive(true);
                PricecAsDiamondDiv.SetActive(true);
                SelectButton.SetActive(false);
                BuyButton.SetActive(true);
                PriceDiv.SetActive(true);
                CoinImg.SetActive(true);
                DiamondImg.SetActive(false);
                PriceText.alignment = TextAlignmentOptions.Center;
                PriceText.text = PlayerPrefs.GetInt("Veh1Price") + "$";
                PriceTextasDiamond.text = PlayerPrefs.GetInt("Veh1PriceDiamond") + "x ♦";
                //print("Vehicle is not yours.");
            }
        }

        else if (selectedCarIndex == 2)
        {
            ClassTextAsset.text = "OFFROAD";
            if (PlayerPrefs.GetInt("Veh2Owned") == 1)
            {
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                //print("Vehicle is Yours");
            }
            else
            {
                BuyButtonDiamond2.SetActive(false);
                BuyButtonDiamond.SetActive(true);
                PricecAsDiamondDiv.SetActive(true);
                SelectButton.SetActive(false);
                BuyButton.SetActive(true);
                PriceDiv.SetActive(true);
                CoinImg.SetActive(true);
                DiamondImg.SetActive(false);
                PriceText.alignment = TextAlignmentOptions.Center;
                PriceText.text = PlayerPrefs.GetInt("Veh2Price") + "$";
                PriceTextasDiamond.text = PlayerPrefs.GetInt("Veh2PriceDiamond") + "x ♦";
                //print("Vehicle is not yours.");
            }
        }

        else if (selectedCarIndex == 3)
        {
            ClassTextAsset.text = "OFFROAD";
            if (PlayerPrefs.GetInt("Veh3Owned") == 1)
            {
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                //print("Vehicle is Yours");
            }
            else
            {
                BuyButtonDiamond2.SetActive(false);
                BuyButtonDiamond.SetActive(true);
                PricecAsDiamondDiv.SetActive(true);
                SelectButton.SetActive(false);
                BuyButton.SetActive(true);
                PriceDiv.SetActive(true);
                CoinImg.SetActive(true);
                DiamondImg.SetActive(false);
                PriceText.alignment = TextAlignmentOptions.Center;
                PriceText.text = PlayerPrefs.GetInt("Veh3Price") + "$";
                PriceTextasDiamond.text = PlayerPrefs.GetInt("Veh3PriceDiamond") + "x ♦";
                //print("Vehicle is not yours.");
            }
        }

        else if (selectedCarIndex == 4)
        {
            ClassTextAsset.text = "OFFROAD";
            if (PlayerPrefs.GetInt("Veh4Owned") == 1)
            {
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                //print("Vehicle is Yours");
            }
            else
            {
                BuyButtonDiamond2.SetActive(false);
                BuyButtonDiamond.SetActive(true);
                PricecAsDiamondDiv.SetActive(true);
                SelectButton.SetActive(false);
                BuyButton.SetActive(true);
                PriceDiv.SetActive(true);
                CoinImg.SetActive(true);
                DiamondImg.SetActive(false);
                PriceText.alignment = TextAlignmentOptions.Center;
                PriceText.text = PlayerPrefs.GetInt("Veh4Price") + "$";
                PriceTextasDiamond.text = PlayerPrefs.GetInt("Veh4PriceDiamond") + "x ♦";
                //print("Vehicle is not yours.");
            }
        }

        else if (selectedCarIndex == 5)
        {
            ClassTextAsset.text = "CASUAL";
            if (PlayerPrefs.GetInt("Veh5Owned") == 1)
            {
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                //print("Vehicle is Yours");
            }
            else
            {
                BuyButtonDiamond2.SetActive(false);
                BuyButtonDiamond.SetActive(true);
                PricecAsDiamondDiv.SetActive(true);
                SelectButton.SetActive(false);
                BuyButton.SetActive(true);
                PriceDiv.SetActive(true);
                CoinImg.SetActive(true);
                DiamondImg.SetActive(false);
                PriceText.alignment = TextAlignmentOptions.Center;
                PriceText.text = PlayerPrefs.GetInt("Veh5Price") + "$";
                PriceTextasDiamond.text = PlayerPrefs.GetInt("Veh5PriceDiamond") + "x ♦";
                //print("Vehicle is not yours.");
            }
        }

        else if (selectedCarIndex == 6)
        {
            ClassTextAsset.text = "CASUAL";
            if (PlayerPrefs.GetInt("Veh6Owned") == 1)
            {
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                //print("Vehicle is Yours");
            }
            else
            {
                BuyButtonDiamond2.SetActive(false);
                BuyButtonDiamond.SetActive(true);
                PricecAsDiamondDiv.SetActive(true);
                SelectButton.SetActive(false);
                BuyButton.SetActive(true);
                PriceDiv.SetActive(true);
                CoinImg.SetActive(true);
                DiamondImg.SetActive(false);
                PriceText.alignment = TextAlignmentOptions.Center;
                PriceText.text = PlayerPrefs.GetInt("Veh6Price") + "$";
                PriceTextasDiamond.text = PlayerPrefs.GetInt("Veh6PriceDiamond") + "x ♦";
                //print("Vehicle is not yours.");
            }
        }

        else if (selectedCarIndex == 7)
        {
            ClassTextAsset.text = "SPORT";
            if (PlayerPrefs.GetInt("Veh7Owned") == 1)
            {
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                //print("Vehicle is Yours");
            }
            else
            {
                BuyButtonDiamond2.SetActive(false);
                BuyButtonDiamond.SetActive(true);
                PricecAsDiamondDiv.SetActive(true);
                SelectButton.SetActive(false);
                BuyButton.SetActive(true);
                PriceDiv.SetActive(true);
                CoinImg.SetActive(true);
                DiamondImg.SetActive(false);
                PriceText.alignment = TextAlignmentOptions.Center;
                PriceText.text = PlayerPrefs.GetInt("Veh7Price") + "$";
                PriceTextasDiamond.text = PlayerPrefs.GetInt("Veh7PriceDiamond") + "x ♦";
                //print("Vehicle is not yours.");
            }
        }

        else if (selectedCarIndex == 8)
        {
            ClassTextAsset.text = "CLASSIC";
            if (PlayerPrefs.GetInt("Veh8Owned") == 1)
            {
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                //print("Vehicle is Yours");
            }
            else
            {
                BuyButtonDiamond2.SetActive(false);
                BuyButtonDiamond.SetActive(true);
                PricecAsDiamondDiv.SetActive(true);
                SelectButton.SetActive(false);
                BuyButton.SetActive(true);
                PriceDiv.SetActive(true);
                CoinImg.SetActive(true);
                DiamondImg.SetActive(false);
                PriceText.alignment = TextAlignmentOptions.Center;
                PriceText.text = PlayerPrefs.GetInt("Veh8Price") + "$";
                PriceTextasDiamond.text = PlayerPrefs.GetInt("Veh8PriceDiamond") + "x ♦";
                //print("Vehicle is not yours.");
            }
        }

        else if (selectedCarIndex == 9)
        {
            ClassTextAsset.text = "MUSCLE";
            if (PlayerPrefs.GetInt("Veh9Owned") == 1)
            {
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                //print("Vehicle is Yours");
            }
            else
            {
                BuyButtonDiamond2.SetActive(false);
                BuyButtonDiamond.SetActive(true);
                PricecAsDiamondDiv.SetActive(true);
                SelectButton.SetActive(false);
                BuyButton.SetActive(true);
                PriceDiv.SetActive(true);
                CoinImg.SetActive(true);
                DiamondImg.SetActive(false);
                PriceText.alignment = TextAlignmentOptions.Center;
                PriceText.text = PlayerPrefs.GetInt("Veh9Price") + "$";
                PriceTextasDiamond.text = PlayerPrefs.GetInt("Veh9PriceDiamond") + "x ♦";
                //print("Vehicle is not yours.");
            }
        }

        else if (selectedCarIndex == 10)
        {
            ClassTextAsset.text = "MUSCLE";
            if (PlayerPrefs.GetInt("Veh10Owned") == 1)
            {
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                //print("Vehicle is Yours");
            }
            else
            {
                BuyButtonDiamond2.SetActive(false);
                BuyButtonDiamond.SetActive(true);
                PricecAsDiamondDiv.SetActive(true);
                SelectButton.SetActive(false);
                BuyButton.SetActive(true);
                PriceDiv.SetActive(true);
                CoinImg.SetActive(true);
                DiamondImg.SetActive(false);
                PriceText.alignment = TextAlignmentOptions.Center;
                PriceText.text = PlayerPrefs.GetInt("Veh10Price") + "$";
                PriceTextasDiamond.text = PlayerPrefs.GetInt("Veh10PriceDiamond") + "x ♦";
                //print("Vehicle is not yours.");
            }
        }

        else if (selectedCarIndex == 11)
        {
            ClassTextAsset.text = "SPORT";
            if (PlayerPrefs.GetInt("Veh11Owned") == 1)
            {
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                //print("Vehicle is Yours");
            }
            else
            {
                BuyButtonDiamond2.SetActive(false);
                BuyButtonDiamond.SetActive(true);
                PricecAsDiamondDiv.SetActive(true);
                SelectButton.SetActive(false);
                BuyButton.SetActive(true);
                PriceDiv.SetActive(true);
                CoinImg.SetActive(true);
                DiamondImg.SetActive(false);
                PriceText.alignment = TextAlignmentOptions.Center;
                PriceText.text = PlayerPrefs.GetInt("Veh11Price")+"$";
                PriceTextasDiamond.text = PlayerPrefs.GetInt("Veh11PriceDiamond") + "x ♦";
                //print("Vehicle is not yours.");
            }
        }

        else if (selectedCarIndex == 12)
        {
            ClassTextAsset.text = "MUSCLE";
            if (PlayerPrefs.GetInt("Veh12Owned") == 1)
            {
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                //print("Vehicle is Yours");
            }
            else
            {
                BuyButtonDiamond2.SetActive(true);
                BuyButtonDiamond.SetActive(false);
                PricecAsDiamondDiv.SetActive(false);
                SelectButton.SetActive(false);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(true);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(true);
                PriceText.alignment = TextAlignmentOptions.Center;
                PriceText.text = PlayerPrefs.GetInt("Veh12Price") + "x ♦";
                //print("Vehicle is not yours.");
            }
        }

        else if (selectedCarIndex == 13)
        {
            ClassTextAsset.text = "SPORT";
            if (PlayerPrefs.GetInt("Veh13Owned") == 1)
            {
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                //print("Vehicle is Yours");
            }
            else
            {
                BuyButtonDiamond2.SetActive(true);
                BuyButtonDiamond.SetActive(false);
                PricecAsDiamondDiv.SetActive(false);
                SelectButton.SetActive(false);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(true);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(true);
                PriceText.alignment = TextAlignmentOptions.Center;
                PriceText.text = PlayerPrefs.GetInt("Veh13Price") + "x ♦";
                //print("Vehicle is not yours.");
            }
        }

        else if (selectedCarIndex == 14)
        {
            ClassTextAsset.text = "SPORT";
            if (PlayerPrefs.GetInt("Veh14Owned") == 1)
            {
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                SelectButton.SetActive(true);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                //print("Vehicle is Yours");
            }
            else
            {
                BuyButtonDiamond2.SetActive(true);
                BuyButtonDiamond.SetActive(false);
                PricecAsDiamondDiv.SetActive(false);
                SelectButton.SetActive(false);
                BuyButton.SetActive(false);
                PriceDiv.SetActive(true);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(true);
                PriceText.alignment = TextAlignmentOptions.Center;
                PriceText.text = PlayerPrefs.GetInt("Veh14Price") + "x ♦";
                //print("Vehicle is not yours.");
            }
        }

    }
    public void SelectVehicle()
    {
        PlayerPrefs.SetInt("SelectedRCCVehicle", selectedCarIndex);
        if (selectedCarIndex == 0)
            PlayerPrefs.SetInt("PlayerClass", 0);
        else if (selectedCarIndex == 1)
            PlayerPrefs.SetInt("PlayerClass", 2);
        else if (selectedCarIndex == 2)
            PlayerPrefs.SetInt("PlayerClass", 2);
        else if (selectedCarIndex == 3)
            PlayerPrefs.SetInt("PlayerClass", 2);
        else if (selectedCarIndex == 4)
            PlayerPrefs.SetInt("PlayerClass", 2);
        else if (selectedCarIndex == 5)
            PlayerPrefs.SetInt("PlayerClass", 1);
        else if (selectedCarIndex == 6)
            PlayerPrefs.SetInt("PlayerClass", 1);
        else if (selectedCarIndex == 7)
            PlayerPrefs.SetInt("PlayerClass", 1);
        else if (selectedCarIndex == 8)
            PlayerPrefs.SetInt("PlayerClass", 1);
        else if (selectedCarIndex == 9)
            PlayerPrefs.SetInt("PlayerClass", 1);
        else if (selectedCarIndex == 10)
            PlayerPrefs.SetInt("PlayerClass", 1);
        else if (selectedCarIndex == 11)
            PlayerPrefs.SetInt("PlayerClass", 1);
        else if (selectedCarIndex == 12)
            PlayerPrefs.SetInt("PlayerClass", 1);
        else if (selectedCarIndex == 13)
            PlayerPrefs.SetInt("PlayerClass", 1);
        else if (selectedCarIndex == 14)
            PlayerPrefs.SetInt("PlayerClass", 1);
    }

    public void BuyVehicle()
    {
        if (selectedCarIndex == 0)
        {
            VehicleBuyMenu.SetActive(true);
        }

        else if (selectedCarIndex == 1)
        {
            VehicleBuyMenu.SetActive(true);
        }

        else if (selectedCarIndex == 2)
        {
            VehicleBuyMenu.SetActive(true);
        }

        else if (selectedCarIndex == 3)
        {
            VehicleBuyMenu.SetActive(true);
        }

        else if (selectedCarIndex == 4)
        {
            VehicleBuyMenu.SetActive(true);
        }

        else if (selectedCarIndex == 5)
        {
            VehicleBuyMenu.SetActive(true);
        }

        else if (selectedCarIndex == 6)
        {
            VehicleBuyMenu.SetActive(true);
        }

        else if (selectedCarIndex == 7)
        {
            VehicleBuyMenu.SetActive(true);
        }

        else if (selectedCarIndex == 8)
        {
            VehicleBuyMenu.SetActive(true);
        }

        else if (selectedCarIndex == 9)
        {
            VehicleBuyMenu.SetActive(true);
        }

        else if (selectedCarIndex == 10)
        {
            VehicleBuyMenu.SetActive(true);
        }

        else if (selectedCarIndex == 11)
        {
            VehicleBuyMenu.SetActive(true);
        }
    }

    public void BuyVehicleDiamond()
    {
        if (selectedCarIndex == 0)
        {
            VehicleBuyMenuDiamond.SetActive(true);
        }

        else if (selectedCarIndex == 1)
        {
            VehicleBuyMenuDiamond.SetActive(true);
        }

        else if (selectedCarIndex == 2)
        {
            VehicleBuyMenuDiamond.SetActive(true);
        }

        else if (selectedCarIndex == 3)
        {
            VehicleBuyMenuDiamond.SetActive(true);
        }

        else if (selectedCarIndex == 4)
        {
            VehicleBuyMenuDiamond.SetActive(true);
        }

        else if (selectedCarIndex == 5)
        {
            VehicleBuyMenuDiamond.SetActive(true);
        }

        else if (selectedCarIndex == 6)
        {
            VehicleBuyMenuDiamond.SetActive(true);
        }

        else if (selectedCarIndex == 7)
        {
            VehicleBuyMenuDiamond.SetActive(true);
        }

        else if (selectedCarIndex == 8)
        {
            VehicleBuyMenuDiamond.SetActive(true);
        }

        else if (selectedCarIndex == 9)
        {
            VehicleBuyMenuDiamond.SetActive(true);
        }

        else if (selectedCarIndex == 10)
        {
            VehicleBuyMenuDiamond.SetActive(true);
        }

        else if (selectedCarIndex == 11)
        {
            VehicleBuyMenuDiamond.SetActive(true);
        }

        else if (selectedCarIndex == 12)
        {
            VehicleBuyMenuDiamond.SetActive(true);
        }

        else if (selectedCarIndex == 13)
        {
            VehicleBuyMenuDiamond.SetActive(true);
        }

        else if (selectedCarIndex == 14)
        {
            VehicleBuyMenuDiamond.SetActive(true);
        }
    }

    public void ConfirmBuyVehicle()
    {
        if (selectedCarIndex == 0)
        {
            if(PlayerPrefs.GetInt("Coins") >= PlayerPrefs.GetInt("Veh0Price"))
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - PlayerPrefs.GetInt("Veh0Price"));
                PlayerPrefs.SetInt("Veh0Owned", (1));
                PlayerPrefs.SetInt("PlayerClass", 0);
                PlayerPrefs.SetInt("SelectedRCCVehicle", 0);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 1)
        {
            if (PlayerPrefs.GetInt("Coins") >= PlayerPrefs.GetInt("Veh1Price"))
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - PlayerPrefs.GetInt("Veh1Price"));
                PlayerPrefs.SetInt("Veh1Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 1);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 2);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 2)
        {
            if (PlayerPrefs.GetInt("Coins") >= PlayerPrefs.GetInt("Veh2Price"))
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - PlayerPrefs.GetInt("Veh2Price"));
                PlayerPrefs.SetInt("Veh2Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 2);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 2);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 3)
        {
            if (PlayerPrefs.GetInt("Coins") >= PlayerPrefs.GetInt("Veh3Price"))
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - PlayerPrefs.GetInt("Veh3Price"));
                PlayerPrefs.SetInt("Veh3Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 3);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 2);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 4)
        {
            if (PlayerPrefs.GetInt("Coins") >= PlayerPrefs.GetInt("Veh4Price"))
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - PlayerPrefs.GetInt("Veh4Price"));
                PlayerPrefs.SetInt("Veh4Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 4);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 2);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 5)
        {
            if (PlayerPrefs.GetInt("Coins") >= PlayerPrefs.GetInt("Veh5Price"))
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - PlayerPrefs.GetInt("Veh5Price"));
                PlayerPrefs.SetInt("Veh5Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 5);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 6)
        {
            if (PlayerPrefs.GetInt("Coins") >= PlayerPrefs.GetInt("Veh6Price"))
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - PlayerPrefs.GetInt("Veh6Price"));
                PlayerPrefs.SetInt("Veh6Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 6);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 7)
        {
            if (PlayerPrefs.GetInt("Coins") >= PlayerPrefs.GetInt("Veh7Price"))
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - PlayerPrefs.GetInt("Veh7Price"));
                PlayerPrefs.SetInt("Veh7Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 7);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 8)
        {
            if (PlayerPrefs.GetInt("Coins") >= PlayerPrefs.GetInt("Veh8Price"))
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - PlayerPrefs.GetInt("Veh8Price"));
                PlayerPrefs.SetInt("Veh8Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 8);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 9)
        {
            if (PlayerPrefs.GetInt("Coins") >= PlayerPrefs.GetInt("Veh9Price"))
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - PlayerPrefs.GetInt("Veh9Price"));
                PlayerPrefs.SetInt("Veh9Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 9);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 10)
        {
            if (PlayerPrefs.GetInt("Coins") >= PlayerPrefs.GetInt("Veh10Price"))
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - PlayerPrefs.GetInt("Veh10Price"));
                PlayerPrefs.SetInt("Veh10Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 10);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 11)
        {
            if (PlayerPrefs.GetInt("Coins") >= PlayerPrefs.GetInt("Veh11Price"))
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - PlayerPrefs.GetInt("Veh11Price"));
                PlayerPrefs.SetInt("Veh11Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 11);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }
    }

    public void ConfirmBuyVehicleDiamond()
    {
        if (selectedCarIndex == 0)
        {
            if(PlayerPrefs.GetInt("Diamond") >= PlayerPrefs.GetInt("Veh0PriceDiamond"))
            {
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Veh0PriceDiamond"));
                PlayerPrefs.SetInt("Veh0Owned", (1));
                PlayerPrefs.SetInt("PlayerClass", 0);
                PlayerPrefs.SetInt("SelectedRCCVehicle", 0);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 1)
        {
            if (PlayerPrefs.GetInt("Diamond") >= PlayerPrefs.GetInt("Veh1PriceDiamond"))
            {
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Veh1PriceDiamond"));
                PlayerPrefs.SetInt("Veh1Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 1);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 2);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 2)
        {
            if (PlayerPrefs.GetInt("Diamond") >= PlayerPrefs.GetInt("Veh2PriceDiamond"))
            {
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Veh2PriceDiamond"));
                PlayerPrefs.SetInt("Veh2Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 2);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 2);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 3)
        {
            if (PlayerPrefs.GetInt("Diamond") >= PlayerPrefs.GetInt("Veh3PriceDiamond"))
            {
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Veh3PriceDiamond"));
                PlayerPrefs.SetInt("Veh3Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 3);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 2);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 4)
        {
            if (PlayerPrefs.GetInt("Diamond") >= PlayerPrefs.GetInt("Veh4PriceDiamond"))
            {
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Veh4PriceDiamond"));
                PlayerPrefs.SetInt("Veh4Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 4);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 2);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 5)
        {
            if (PlayerPrefs.GetInt("Diamond") >= PlayerPrefs.GetInt("Veh5PriceDiamond"))
            {
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Veh5PriceDiamond"));
                PlayerPrefs.SetInt("Veh5Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 5);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 6)
        {
            if (PlayerPrefs.GetInt("Diamond") >= PlayerPrefs.GetInt("Veh6PriceDiamond"))
            {
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Veh6PriceDiamond"));
                PlayerPrefs.SetInt("Veh6Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 6);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 7)
        {
            if (PlayerPrefs.GetInt("Diamond") >= PlayerPrefs.GetInt("Veh7PriceDiamond"))
            {
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Veh7PriceDiamond"));
                PlayerPrefs.SetInt("Veh7Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 7);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 8)
        {
            if (PlayerPrefs.GetInt("Diamond") >= PlayerPrefs.GetInt("Veh8PriceDiamond"))
            {
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Veh8PriceDiamond"));
                PlayerPrefs.SetInt("Veh8Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 8);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 9)
        {
            if (PlayerPrefs.GetInt("Diamond") >= PlayerPrefs.GetInt("Veh9PriceDiamond"))
            {
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Veh9PriceDiamond"));
                PlayerPrefs.SetInt("Veh9Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 9);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 10)
        {
            if (PlayerPrefs.GetInt("Diamond") >= PlayerPrefs.GetInt("Veh10PriceDiamond"))
            {
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Veh10PriceDiamond"));
                PlayerPrefs.SetInt("Veh10Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 10);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 11)
        {
            if (PlayerPrefs.GetInt("Diamond") >= PlayerPrefs.GetInt("Veh11PriceDiamond"))
            {
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Veh11PriceDiamond"));
                PlayerPrefs.SetInt("Veh11Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 11);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 12)
        {
            if (PlayerPrefs.GetInt("Diamond") >= PlayerPrefs.GetInt("Veh12Price"))
            {
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Veh12Price"));
                PlayerPrefs.SetInt("Veh12Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 12);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 13)
        {
            if (PlayerPrefs.GetInt("Diamond") >= PlayerPrefs.GetInt("Veh13Price"))
            {
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Veh13Price"));
                PlayerPrefs.SetInt("Veh13Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 13);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }

        else if (selectedCarIndex == 14)
        {
            if (PlayerPrefs.GetInt("Diamond") >= PlayerPrefs.GetInt("Veh14Price"))
            {
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Veh14Price"));
                PlayerPrefs.SetInt("Veh14Owned", (1));
                PlayerPrefs.SetInt("SelectedRCCVehicle", 14);
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
                PriceDiv.SetActive(false);
                CoinImg.SetActive(false);
                DiamondImg.SetActive(false);
                PlayerPrefs.SetInt("PlayerClass", 1);
                PricecAsDiamondDiv.SetActive(false);
                BuyButtonDiamond.SetActive(false);
                BuyButtonDiamond2.SetActive(false);
            }
            else
            {
                VehicleBuyFail.SetActive(true);
            }
        }
    }
}
