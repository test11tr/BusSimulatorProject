using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using TMPro;
using System;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    int Chance;
    int RandomMoney;
    int RandomDiamond;
    public TMP_Text GiftText;
    public GameObject GiftPanel;
    [SerializeField] double nextGiftDelay = 4f;
    [SerializeField] float checkForGiftDelay = 5f;
    private bool isGiftReady = false;
    [SerializeField] GameObject giftNotification;
    [SerializeField] GameObject noMoreGiftPanel;
    [SerializeField] Button GiftButton;


    string gameId = "4205809";

    void Start()
    {
        Initialize();
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
        StopAllCoroutines();
        StartCoroutine(CheckForFreeGifts());
    }
    void Initialize()
    {
        GiftButton.onClick.RemoveAllListeners();
        GiftButton.onClick.AddListener(OnGiftButtonClick);
    }

    public void PlayRewardedAdMainMenu()
    {

            if (Advertisement.IsReady("Rewarded_Android_Menu"))
            {
                Advertisement.Show("Rewarded_Android_Menu");
            }
    }
    IEnumerator CheckForFreeGifts()
    {
        while (true)
        {
            if (!isGiftReady)
            {
                DateTime currentDatetime = DateTime.Now;
                DateTime giftClaimDatetime = DateTime.Parse(PlayerPrefs.GetString("gift_Claim_Datetime", currentDatetime.ToString()));

                //get total Hours between this 2 dates
                double elapsedHours = (currentDatetime - giftClaimDatetime).TotalHours;
                if (elapsedHours >= nextGiftDelay || PlayerPrefs.GetInt("FirstGift") == 0)
                    ActivateGift();
                else
                    DesactivateGift();
            }

            yield return new WaitForSeconds(checkForGiftDelay);
        }
    }

    void ActivateGift()
    {
        isGiftReady = true;

        noMoreGiftPanel.SetActive(false);
        giftNotification.SetActive(true);
    }

    public void DesactivateGift()
    {
        isGiftReady = false;
        noMoreGiftPanel.SetActive(true);
        giftNotification.SetActive(false);
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
        //print("Ads Ready.");
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
        //print("Error: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
        //print("Ads started.");
    }

    void OnGiftButtonClick()
    {
        GiftPanel.SetActive(true);
        noMoreGiftPanel.SetActive(false);
        if(isGiftReady)
        {
            if (Advertisement.IsReady("Rewarded_Android_Menu"))
            {
                Advertisement.Show("Rewarded_Android_Menu");
            }
        }
        else
        {
            noMoreGiftPanel.SetActive(true);
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //throw new System.NotImplementedException();
        
        if (placementId == "Rewarded_Android_Menu" && showResult == ShowResult.Finished)
        {
            Chance = UnityEngine.Random.Range(1, 10);
            if (PlayerPrefs.GetString("_language") == "tr"){ //T�RK�E
                if(Chance >= 0 || Chance <= 3)
                {
                    RandomMoney = UnityEngine.Random.Range(250, 1000);
                    PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + RandomMoney);
                    GiftText.text = "Bedava Odulunuz:\n" + RandomMoney + "$";
                }
                else if(Chance >= 4 || Chance <= 8)
                {
                    RandomMoney = UnityEngine.Random.Range(500, 2500);
                    PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + RandomMoney);
                    GiftText.text = "Bedava Odulunuz:\n" + RandomMoney + "$";
                }
                else if(Chance >= 9 || Chance <= 10)
                {
                    RandomDiamond = UnityEngine.Random.Range(1, 5);
                    PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + RandomDiamond);
                    GiftText.text = "Bedava Odulunuz:\n" + RandomDiamond + "x ♦!";
                }
            }
            else if (PlayerPrefs.GetString("_language") == "fr"){ //FRANSIZCA
                if(Chance >= 0 || Chance <= 3)
                {
                    RandomMoney = UnityEngine.Random.Range(250, 1000);
                    PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + RandomMoney);
                    GiftText.text = "Votre cadeau gratuit est:\n" + RandomMoney + "$";
                }
                else if(Chance >= 4 || Chance <= 8)
                {
                    RandomMoney = UnityEngine.Random.Range(500, 2500);
                    PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + RandomMoney);
                    GiftText.text = "Votre cadeau gratuit est:\n" + RandomMoney + "$";
                }
                else if(Chance >= 9 || Chance <= 10)
                {
                    RandomDiamond = UnityEngine.Random.Range(1, 5);
                    PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + RandomDiamond);
                    GiftText.text = "Votre cadeau gratuit est:\n" + RandomDiamond + "x ♦!";
                }
            }
            else if (PlayerPrefs.GetString("_language") == "sp"){ //FRANSIZCA
                if(Chance >= 0 || Chance <= 3)
                {
                    RandomMoney = UnityEngine.Random.Range(250, 1000);
                    PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + RandomMoney);
                    GiftText.text = "Tu regalo gratis es :\n" + RandomMoney + "$";
                }
                else if(Chance >= 4 || Chance <= 8)
                {
                    RandomMoney = UnityEngine.Random.Range(500, 2500);
                    PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + RandomMoney);
                    GiftText.text = "Tu regalo gratis es :\n" + RandomMoney + "$";
                }
                else if(Chance >= 9 || Chance <= 10)
                {
                    RandomDiamond = UnityEngine.Random.Range(1, 5);
                    PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + RandomDiamond);
                    GiftText.text = "Tu regalo gratis es:\n" + RandomDiamond + "x ♦!";
                }
            }
            else if (PlayerPrefs.GetString("_language") == "de"){ //FRANSIZCA
                if(Chance >= 0 || Chance <= 3)
                {
                    RandomMoney = UnityEngine.Random.Range(250, 1000);
                    PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + RandomMoney);
                    GiftText.text = "Ihr kostenloses Geschenk ist:\n" + RandomMoney + "$";
                }
                else if(Chance >= 4 || Chance <= 8)
                {
                    RandomMoney = UnityEngine.Random.Range(500, 2500);
                    PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + RandomMoney);
                    GiftText.text = "Ihr kostenloses Geschenk ist:\n" + RandomMoney + "$";
                }
                else if(Chance >= 9 || Chance <= 10)
                {
                    RandomDiamond = UnityEngine.Random.Range(1, 5);
                    PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + RandomDiamond);
                    GiftText.text = "Ihr kostenloses Geschenk ist:\n" + RandomDiamond + "x ♦!";
                }
            }
            else{
                if(Chance >= 0 || Chance <= 3)
                {
                    RandomMoney = UnityEngine.Random.Range(250, 1000);
                    PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + RandomMoney);
                    GiftText.text = "Your Free Gift is:\n" + RandomMoney + "$";
                }
                else if(Chance >= 4 || Chance <= 8)
                {
                    RandomMoney = UnityEngine.Random.Range(500, 2500);
                    PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + RandomMoney);
                    GiftText.text = "Your Free Gift is:\n" + RandomMoney + "$";
                }
                else if(Chance >= 9 || Chance <= 10)
                {
                    RandomDiamond = UnityEngine.Random.Range(1, 5);
                    PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + RandomDiamond);
                    GiftText.text = "Your Free Gift is:\n" + RandomDiamond + "x ♦!";
                }
            }
            PlayerPrefs.SetInt("FirstGift", 1);
            isGiftReady = false;
            PlayerPrefs.SetString("gift_Claim_Datetime", DateTime.Now.ToString());
            //DesactivateGift();
        }
    }
}
