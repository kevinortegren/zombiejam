﻿using UnityEngine;
using System.Collections;
using System;

public class Player : controller {

	private float timeWhenFired = 0.0f;
	public GameObject activeWeapon;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
		// Temp movement.
		if(Input.GetKey(KeyCode.RightArrow))
			GetComponent<CharacterController>().Move(new Vector3(1,0,0) * 0.1f);
		else if(Input.GetKey(KeyCode.LeftArrow))
			GetComponent<CharacterController>().Move(-Vector3.right * 0.1f);
		
		// Shoot logic.
		if(Input.GetKey(KeyCode.Space))
		{
			Shoot();
		}
		
		// Level bounds check.
		Vector3 position = transform.position;
		if(position.x < Level.LevelWidth && position.x > 0 
			&& position.y > 0 && position.y < Level.LevelHeight)
		{
				
		}

		base.UpdateInput ();
	}

	protected override void ProcessInput(JOYSTICKBUTTON button)
	{
		switch(button)
		{
		case JOYSTICKBUTTON.JUMP: 
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));
			break;
		}
		case JOYSTICKBUTTON.FIRE: 
		{
			Shoot();
			break;
		}
		default:
			break;
		}
	}

	void Shoot()
	{
		Weapon weapon = activeWeapon.GetComponent<Weapon>();
	
		if(Time.time >= timeWhenFired + weapon.cooldown)
		{
			weapon.Fire(transform.position);		
			timeWhenFired = Time.time;
		}
	}
}