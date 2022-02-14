using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClassCard : MonoBehaviour {

	public int cooldownQ = 10;
	public int cooldownE = 10;
	public GameObject secondaryCard;
	public GameObject threeCardsRight;
	public GameObject threeCardsLeft;
	public TextMeshProUGUI textMeshProQ;
	public TextMeshProUGUI textMeshProE;

	[HideInInspector]
	public static bool cooldownQReady = true;
	public static bool cooldownEReady = true;


	void Start ()
    {
		secondaryCard.SetActive(false);
		textMeshProQ = textMeshProQ.GetComponent<TextMeshProUGUI>();
		textMeshProE = textMeshProE.GetComponent<TextMeshProUGUI>();
		//TextMeshPro textMeshProR = TMPGameObjectR.GetComponent<TextMeshPro>();
	}


	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("q") && cooldownQReady)	
        {
			StartCoroutine(cooldownQTracker(cooldownQ));
		}
		if (Input.GetKeyDown("e") && cooldownEReady)
        {
			StartCoroutine(cooldownETracker(cooldownE));
        }
	}

	public static bool cooldownQReadyGet()
    {
		return !cooldownQReady; // Has to be opposite, cant figure out how to do it any other way
    }

	public IEnumerator cooldownQTracker (int cooldownQ) 
    {
		cooldownQReady = false;
		secondaryCard.SetActive(true);
		StartCoroutine(cooldownQTMP(cooldownQ));
		yield return new WaitForSeconds(cooldownQ);
		secondaryCard.SetActive(false);
		cooldownQReady = true;
	}

	public IEnumerator cooldownQTMP (int cooldownQ)
    {
		for (int i = cooldownQ; i > 0; i--)
        {
			textMeshProQ.SetText(i.ToString());
			yield return new WaitForSeconds(1);
		}
		threeCardsLeft.SetActive(false);
		textMeshProQ.SetText("Q");
    }

	public IEnumerator cooldownETracker (int cooldownE)
    {
		cooldownEReady = false;
		threeCardsRight.SetActive(true);
		if (!cooldownQReady)
			threeCardsLeft.SetActive(true);
		StartCoroutine(cooldownETMP(cooldownE));
		// Next attack throws 3 cards out instead of 1 in a triangle formation
		yield return new WaitForSeconds(cooldownE);
		threeCardsRight.SetActive(false);
		cooldownEReady = true;
    }

	public IEnumerator cooldownETMP (int cooldownE)
    {
		for (int i = cooldownE; i > 0; i--)
        {
			textMeshProE.SetText(i.ToString());
			yield return new WaitForSeconds(1);
		}
		textMeshProE.SetText("E");
    }
}
