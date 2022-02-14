using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayerHealth : MonoBehaviour 
{
	[Header("Health Parameters")]
	[SerializeField] private int maxHealth;
	[SerializeField] private AudioClip hitSound;
	private float currentHealth = 0;
	private AudioSource playerAudioSource;

	[Header("UI")]
	[SerializeField] private Image healthBar;
	
	void Start () 
	{
		playerAudioSource = GetComponent<AudioSource>();
		currentHealth = maxHealth;
	}

	public void RemoveHealth(float healthToRemove)
	{
		//playerAudioSource.PlayOneShot(hitSound);        Change to sound when hit
		currentHealth -= healthToRemove;
		UpdateHealthBar();
	}

	public void AddHealth(float healthToAdd)
	{
		if(currentHealth < maxHealth)
		{
			currentHealth += healthToAdd;
			if (currentHealth > maxHealth)
				currentHealth = maxHealth;
			UpdateHealthBar();
		}
	}

	private void UpdateHealthBar()
	{
		healthBar.fillAmount = currentHealth / maxHealth;
	}
	
}
