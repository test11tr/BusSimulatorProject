using UnityEngine;

public class RATEUS : MonoBehaviour
{
    public void Rate()
	{
#if UNITY_IOS
        PlayerPrefs.SetInt("RatedUs", 1);
        Application.OpenURL("https://apps.apple.com/tr/app/parking-master-asphalt-offroad/id1519546546");
#else
        PlayerPrefs.SetInt("RatedUs", 1);
        Application.OpenURL("market://details?id=com.parkingmasterasphaltoffroad.testtest");
#endif
    }

	public void Feedback()
	{
        PlayerPrefs.SetInt("RatedUs", 1);
        Application.OpenURL("mailto:gamefabrikateam@gmail.com");
    }
    
    public void DontShowAgain()
    {
        PlayerPrefs.SetInt("DontShowRateUs", 1);
    }
}