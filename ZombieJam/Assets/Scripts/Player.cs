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

	Quaternion currentAim = Quaternion.identity;
	
	float currentAngle = 0.0f;
    bool flipped = true;

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

	void RotateArm()
	{
        if (aimVec != Vector3.zero)
        {
            GameObject arm = GameObject.FindGameObjectWithTag("Arm");

            float angle = (float)Math.Atan2(aimVec.y, aimVec.x) * Mathf.Rad2Deg;

            Quaternion newAim = Quaternion.Euler(new Vector3(0, 0, angle));
            currentAim = Quaternion.Slerp(this.currentAim, newAim, 0.2f);

            arm.transform.rotation = currentAim;          
        }
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
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 600));
			state = PLAYERSTATE.AIR;
		}
	}

	protected override void ProcessState()
	{
		switch (base.currentState) {
			case STATE.RUNNINGLEFT:
			{
				animation.CrossFade ("Running", 0.3f);
                if (previousState != currentState && previousState != STATE.WALKINGLEFT)
				{
					transform.Rotate (0, 180, 0);
				}
                previousState = currentState;	
				break;
			}
			case STATE.WALKINGLEFT:
			{
				animation.CrossFade ("Walking", 0.3f);
                if (previousState != currentState && previousState != STATE.RUNNINGLEFT)
				{
					transform.Rotate (0, 180, 0);
				}
                previousState = currentState;	
				break;
			}
			case STATE.RUNNINGRIGHT:
			{
				animation.CrossFade ("Running", 0.3f);
                if (previousState != currentState && previousState != STATE.WALKINGRIGHT)
				{
					transform.Rotate (0, 180, 0);
				}
                previousState = currentState;
				break;
			}
			case STATE.WALKINGRIGHT:
			{
				animation.CrossFade ("Walking", 0.3f);
                if (previousState != currentState && previousState != STATE.RUNNINGRIGHT)
				{
					transform.Rotate (0, 180, 0);
				}
                previousState = currentState;	
				break;
			}
			default:
			{
				animation.CrossFade ("Idle", 0.3f);
				break;
			}
		}

        // Use aim direction to rotate arm.
		RotateArm();	
	}

	void Shoot()
	{
		Weapon weapon = activeWeapon.GetComponent<Weapon>();
	
		if(Time.time >= timeWhenFired + weapon.cooldown)
		{
			// If the controller has an aiming direction.
			if(aimVec != Vector3.zero)
				latestAimingDirection = aimVec;

            // TODO: Use weapon instead of hand.
            GameObject arm = GameObject.FindGameObjectWithTag("Hand");

            //print(arm.transform.position);
            //print(transform.position);

            weapon.Fire(arm.transform.position, new Vector2(latestAimingDirection.x, latestAimingDirection.y));		
			timeWhenFired = Time.time;
		}
	}
}
