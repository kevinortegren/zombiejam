﻿using UnityEngine;
using System.Collections;

public class Blaster : Weapon {

	public GameObject bullet;

	public Blaster() : base(0.4f)
	{
		
	}

	public override void Fire (Vector2 playerPosition)
	{
		Instantiate(bullet, new Vector3(playerPosition.x, playerPosition.y, 0.0f), Quaternion.identity);
	}
}