using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisonItem : MonoBehaviour
{
	[SerializeField] ParkingManager triggerManager;
	bool CanCollid;

    private void Start()
    {
		triggerManager = GameObject.FindObjectOfType<ParkingManager>();
	}

    //When car is colide with parking items
    void OnCollisionEnter(Collision col)
	{
		if (!CanCollid)
		{
			if (col.gameObject.tag == "Player")
			{
				//print("CollisionHit!");
				//Increase TriggerManager Collision Counts
				triggerManager.CollisionCount++;
				//print(triggerManager.CollisionCount);
				//PlayerPrefs.SetInt("TotalCollisions", PlayerPrefs.GetInt("TotalCollisions") + 1);

				//Play collision Alarm sound
				//triggerManager.AlarmSound.Play();

				//Internal usage--------------------
				CanCollid = true;
				StartCoroutine(CanCollids());
				//---------------------

				//Update collision count text
				triggerManager.CollistionCountText.text = triggerManager.CollisionCount.ToString();

				//If collision counts is more than 3,Stop game and show Failed menu Object
				if (triggerManager.CollisionCount >= triggerManager.CollisionLimit)
				{
					// BRING THE MENU BITCH
					//triggerManager.FailedMenu.SetActive(true);
					//RCC.SetEngine(Controller, false); Artýk ParkingManager'da
					triggerManager.CollisionFailed();
					//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
					//PlayerPrefs.SetInt("TotalFailed", PlayerPrefs.GetInt("TotalFailed") + 1);
					//Destroy TriggerManager
					//Destroy(triggerManager);
				}
			}
		}
	}

	//Internal Usage....
	IEnumerator CanCollids()
	{
		yield return new WaitForSeconds(3f);
		CanCollid = false;
	}
}
