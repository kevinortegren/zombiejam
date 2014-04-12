﻿using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float cooldown;
	
	public Weapon(float cooldown)
	{
		this.cooldown = cooldown;
	}
	
	public virtual void Fire(Vector3 playerPosition, Vector2 direction) {}
}
