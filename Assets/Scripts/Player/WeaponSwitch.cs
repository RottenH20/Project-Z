using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour 
{
	public List<Transform> weapons;
	int selectedWeapon;

	[Header("Weapon Objects")]
	public GameObject card1, card2, card3, card4, card5;


	void Start () 
	{
		selectedWeapon = 0;
		UpdateWeapon();
	}
	

	void Update () 
	{
		if (Input.GetAxis("Mouse ScrollWheel") < 0) 
		{
			if (selectedWeapon - 1 < 0)
            {
				selectedWeapon = weapons.Count - 1;
            }
			else
            {
				selectedWeapon--;
			}
		}
		if(Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			if (selectedWeapon + 1 > weapons.Count - 1)
            {
				selectedWeapon = 0;
			}
			else
            {
				selectedWeapon++;
			}
		}


		
		// Needs to be automated
		if (Input.GetKeyDown(KeyCode.Alpha1)) 
		{
			selectedWeapon = 0;
		}
		if(Input.GetKeyDown(KeyCode.Alpha2) && weapons.Count > 1)
		{
			selectedWeapon = 1;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3) && weapons.Count > 1)
		{
			selectedWeapon = 2;
		}

		UpdateWeapon();
	}

	void UpdateWeapon()
	{
		for(int i = 0; i < weapons.Count; i++)
		{
			if(i == selectedWeapon)
			{
				weapons[i].gameObject.SetActive(true);
			} else
			{
				weapons[i].gameObject.SetActive(false);
			}
		}
	}
}
