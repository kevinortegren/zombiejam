using UnityEngine;
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

	protected override void ProcessState(STATE State)
	{

		switch (State) {
		case STATE.MOVINGLEFT:
				{
						animation.CrossFade ("Running", 0.3f);
						if(previousState != State)
						{
							transform.Rotate (0, 180, 0);
						}
						previousState = State;	
						break;
				}
		case STATE.MOVINGRIGHT:
				{
						animation.CrossFade ("Running", 0.3f);
						if(previousState != State)
						{
							transform.Rotate (0, 180, 0);
						}
						previousState = State;
						break;
				}
		default:
				{
						animation.CrossFade ("Idle", 0.3f);
						break;
				}
			}

		}
	void Shoot()
	{
		Weapon weapon = activeWeapon.GetComponent<Weapon>();
	
		if(Time.time >= timeWhenFired + weapon.cooldown)
		{
			weapon.Fire(transform.position, new Vector2(-1, 0));		
			timeWhenFired = Time.time;
		}
	}
}
