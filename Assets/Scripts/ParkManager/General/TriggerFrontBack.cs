using UnityEngine;
using System.Collections;

//Public enum for select trigger type in Inspector
public enum TriggerType{Front,Back}

public class TriggerFrontBack : MonoBehaviour
{
	// ParkingManager handler
	public ParkingManager manager;

	// Is front trigger or back?
	public TriggerType triggerType;

	string NotCorrectContent;
	string NotCorrectHeader;

	void Start()
	{
		if (PlayerPrefs.GetString("_language") == "tr")
		{
			NotCorrectContent = "Aracı dogru pozisyonda, duzgun sekilde park ediniz.";
			NotCorrectHeader = "Düzgün Park Edilemedi!";
		}else if (PlayerPrefs.GetString("_language") == "fr")
		{
			NotCorrectContent = "Garez le vehicule dans la bonne position et correctement.";
			NotCorrectHeader = "Pas gare correctement!";
		}else if (PlayerPrefs.GetString("_language") == "sp")
		{
			NotCorrectContent = "Estacione el vehiculo en la posicion correcta y correctamente.";
			NotCorrectHeader = "No se pudo estacionar correctamente!";
		}else if (PlayerPrefs.GetString("_language") == "de")
		{
			NotCorrectContent = "Parken Sie das Fahrzeug in der richtigen Position und ordnungsgemaB.";
			NotCorrectHeader = "Konnte nicht richtig parken!";
		}
		else
		{
			NotCorrectContent = "Park the vehicle properly, in the correct position.";
			NotCorrectHeader = "Not Parked Correctly!";
		}
	}

	// On parking triggers enter
	void OnTriggerEnter (Collider col)
	{
		// Is front trigger
		if (triggerType == TriggerType.Front) {
			if (col.tag == "VehFront")
			{
				manager.tFront = true;
			}
			else
				TooltipSystem.Show(NotCorrectContent, NotCorrectHeader);
		} else {// Or back trigger?
			if (col.tag == "vehBack") {
				manager.tBack = true;
			}
		}
	}
	// On parking triggers exit
	void OnTriggerExit (Collider col)
	{
		TooltipSystem.Hide();
		if (triggerType == TriggerType.Front) {
			if (col.tag == "VehFront") {
				manager.tFront = false;
			}
		} else {
			if (col.tag == "vehBack") {
				manager.tBack = false;
			}
		}
	}
}