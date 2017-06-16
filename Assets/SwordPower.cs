﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPower : MonoBehaviour {
	public int damage;
	public float speed;
	public float lifeTime;
	Vector2 direction;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, lifeTime);
		if (direction.x < 0)
			transform.localRotation = Quaternion.Euler(0, 180, 0);
	}
	
	// Update is called once per frame
	void Update () {
		float actualSpeed = speed * Time.deltaTime;
		transform.position += new Vector3(direction.x, 0, 0) * actualSpeed;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Monster")
		{
			if (other.transform.parent.GetComponent<monsterHealth>() != null)
			{
				other.transform.parent.GetComponent<monsterHealth>().Damaged(damage);
				Destroy(gameObject);
			}
		}

		
	}

	public void SetDirection(Vector2 direction)
	{
		this.direction = direction;
	}
}
