using UnityEngine;
using System.Collections;
using System;

public class Player : controller {

	enum PLAYERSTATE
	{
		AIR,
		GROUND
	}

	public GameObject activeWeapon;

	private float timeWhenFired = 0.0f;
	private Vector3 latestAimingDirection = Vector3.right;
	private PLAYERSTATE state = PLAYERSTATE.GROUND;

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

	void OnCollisionEnter2D(Collision2D hit)
	{
		if(hit.gameObject.tag == "Ground")
		{
			state = PLAYERSTATE.GROUND;
		}
	}

	protected override void ProcessInput(JOYSTICKBUTTON button)
	{
		switch(button)
		{
		case JOYSTICKBUTTON.JUMP: 
		{
			Jump();
			animation.Play("Jumping");
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

	void Jump()
	{
		if(state == PLAYERSTATE.GROUND)
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));
			state = PLAYERSTATE.AIR;
		}
	}

	protected override void ProcessState(STATE State)
	{
		switch (State) {
		case STATE.RUNNINGLEFT:
				{
						animation.CrossFade ("Running", 0.3f);
						if(previousState != State && previousState != STATE.WALKINGLEFT)
						{
							transform.Rotate (0, 180, 0);
						}
						previousState = State;	
						break;
				}
		case STATE.WALKINGLEFT:
		{
			animation.CrossFade ("Walking", 0.3f);
			if(previousState != State && previousState != STATE.RUNNINGLEFT)
			{
				transform.Rotate (0, 180, 0);
			}
			previousState = State;	
			break;
		}
		case STATE.RUNNINGRIGHT:
				{
						animation.CrossFade ("Running", 0.3f);
			if(previousState != State && previousState != STATE.WALKINGRIGHT)
						{
							transform.Rotate (0, 180, 0);
						}
						previousState = State;
						break;
				}
		case STATE.WALKINGRIGHT:
		{
			animation.CrossFade ("Walking", 0.3f);
			if(previousState != State && previousState != STATE.RUNNINGRIGHT)
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
			// If the controller has an aiming direction.
			if(aimVec != Vector3.zero)
				latestAimingDirection = aimVec;		
				
		
			weapon.Fire(transform.position, new Vector2(latestAimingDirection.x, latestAimingDirection.y));		
			timeWhenFired = Time.time;
		}
	}
}
