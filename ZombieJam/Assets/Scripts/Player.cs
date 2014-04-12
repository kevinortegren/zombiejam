using UnityEngine;
using System.Collections;
using System;

public class Player : controller {

	enum PLAYERSTATE
	{
		AIR,
		GROUND
	}

    enum QUESTIONSTATE
    {
        NONE,
        INTRO,
        INPUT,
        WAITING

    }

	public GameObject activeWeapon;
    public float jumpForce = 700;

	private float timeWhenFired = 0.0f;
	private Vector3 latestAimingDirection = Vector3.right;
	private PLAYERSTATE state = PLAYERSTATE.GROUND;
    private QUESTIONSTATE qstate = QUESTIONSTATE.NONE;

	Quaternion currentAim = Quaternion.identity;

    private Transform shoulder;
    private Transform hand;

    private float introTime = 0.0f;

	// Use this for initialization
	void Start () {

        Transform[] joints = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform t in joints)
        {
            if (t.name == "Blaster")
            {
                hand = t.GetChild(0);
            }

            if (t.name == "RightShoulder")
            {
                shoulder = t;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (qstate == QUESTIONSTATE.INTRO)
        {
            introTime += Time.deltaTime;

            if (introTime > 2.0f)
            {
                print("Intro Done.");
                qstate = QUESTIONSTATE.INPUT;
                introTime = 0.0f;
            }
        }
        if (qstate == QUESTIONSTATE.INPUT)
        {
            base.UpdateQuestionInput();
        }
        else
        {
            base.UpdateInput();
        }
	}

	void RotateArm()
	{
        if (aimVec != Vector3.zero)
        {
            float angle = (float)Math.Atan2(aimVec.y, aimVec.x) * Mathf.Rad2Deg;

            Quaternion newAim = Quaternion.Euler(new Vector3(0, 0, angle));
            currentAim = Quaternion.Slerp(this.currentAim, newAim, 0.2f);

            shoulder.rotation = currentAim;          
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

    protected override void ProcessQuestionInput(JOYSTICKBUTTON button)
    {
        switch (button)
        {
            case JOYSTICKBUTTON.JUMP:
                {
                    print("A");
                    qstate = QUESTIONSTATE.WAITING;
                    break;
                }
            case JOYSTICKBUTTON.FIRE:
                {
                    print("B");
                    qstate = QUESTIONSTATE.WAITING;
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
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
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

            weapon.Fire(gameObject, hand.position, new Vector2(latestAimingDirection.x, latestAimingDirection.y));		
			timeWhenFired = Time.time;
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Test")
        {
            if (qstate == QUESTIONSTATE.NONE)
            {
                print("Enter zone.");
                qstate = QUESTIONSTATE.INTRO;
            }
        }
    }
}
