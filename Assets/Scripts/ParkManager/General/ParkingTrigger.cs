using UnityEngine;
using System.Collections;

public class ParkingTrigger : MonoBehaviour
{
	// Trigger number
	public int tNum;
	// ParkingManager handler
	public ParkingManager tManager;

	void OnTriggerStay (Collider col)
	{
		// Debug.Log(col.tag);
		//if (col.tag == "Player") {
			//Debug.Log("here");
			if (tNum == 1) 
				tManager.t0 = true;
			else if (tNum == 2)
				tManager.t1 = true;
			else if (tNum == 3)
				tManager.t2 = true;
			else if (tNum == 4)
				tManager.t3 = true;
		//}   
	}

	void OnTriggerExit (Collider col)
	{
		//if (col.tag == "Player") {
			if (tNum == 1)
				tManager.t0 = false;
			else if (tNum == 2)
				tManager.t1 = false;
			else if (tNum == 3)
				tManager.t2 = false;
			else if (tNum == 4)
				tManager.t3 = false;						
		//}
	}
}