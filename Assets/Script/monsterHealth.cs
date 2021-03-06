﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class monsterHealth : MonoBehaviour {

	public  int maxHealth = 9;
	public int currentHealth;
	public GameObject currentHpBar;
    bool AttackButton = false;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;	
		if (currentHpBar != null)
			UpdateHealthBar();
	}
	
	// Update is called once per frame
	void UpdateHealthBar () {
		float healthRatio = (float)currentHealth / (float)maxHealth;
		currentHpBar.transform.localScale = new Vector3(healthRatio,1,1);
	}

	public void Heal(int healAmount)
	{
		currentHealth += healAmount;
		if (currentHealth > maxHealth) 
			currentHealth = maxHealth;
		UpdateHealthBar();
	}

	public void Damaged(int damageAmount)
	{
		currentHealth -= damageAmount;
		if ((gameObject.name == "Boss") && (currentHealth < 5))
		{
			currentHealth = 5;
			SceneManager.LoadScene("Scene_boss2");
		}
		if (currentHealth < 0) 
			currentHealth = 0;
		if (currentHpBar != null)
			UpdateHealthBar();
	}

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.M)){
			Damaged(1);
		}
		if(Input.GetKeyDown(KeyCode.N)){
			Heal(1);
		}
		if (currentHealth == 0)
		{
			if (gameObject.GetComponent<ItemDrop>() != null)
				DropItem();
			Destroy(gameObject);
		}
	}
    public void OnTriggerStay2D (Collider2D other)
    {
        // if (AttackButton)
        // {
        //     if (other.gameObject.tag == "Monstar")
        //     {
        //         maxHealth = maxHealth - 1;
        //     }
        // }
    }

	void DropItem()
	{
		ItemDrop drop = gameObject.GetComponent<ItemDrop>();
		drop.DropExp(5);
		drop.DropPotion();
	}
}
