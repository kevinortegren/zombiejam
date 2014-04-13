using UnityEngine;
using System.Collections;
using System;

public class Player : controller {

	enum PLAYERSTATE
	{
		AIR,
		GROUND
	}

    public enum QUESTIONSTATE
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

    private int score = 0;

    public QUESTIONSTATE qstate = QUESTIONSTATE.NONE;

    private GameObject currentQZone;

	Quaternion currentAim = Quaternion.identity;

    private Transform shoulder;
    private Transform hand;

    private float introTime = 0.0f;

    public GameObject guitext;

    private GUIText gtext;
    public Color privColor;

	// Use this for initialization
	void Start () {
        Global.playerList.Add(this);
        GameObject gobject = (GameObject)Instantiate(guitext, transform.position, transform.rotation);
        gtext = gobject.GetComponent<GUIText>();
        gtext.transform.position = new Vector3(0.15f * (float)(JoyStickNum - 1.0f), 0.05f, 0.0f);

        switch (JoyStickNum)
        {
            case 1:
            {
                privColor = gtext.color = Color.red;
                
                SkinnedMeshRenderer r = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
                r.material.color = Color.red;

                break;
            }
            case 2:
            {
                privColor = gtext.color = Color.blue;

                SkinnedMeshRenderer r = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
                r.material.color = Color.blue;

                break;
            }
            case 3:
            {
                privColor = gtext.color = Color.green;

                SkinnedMeshRenderer r = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
                r.material.color = Color.green;

                break;
            }
            case 4:
            {
                privColor = gtext.color = Color.yellow;

                SkinnedMeshRenderer r = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
                r.material.color = Color.yellow;

                break;
            }
            default:
                break;
        }

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
        else if (qstate == QUESTIONSTATE.INPUT)
        {
            base.UpdateQuestionInput();
        }
        else if(qstate == QUESTIONSTATE.NONE)
        {
            base.UpdateInput();

            Shoot();
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
                    qstate = QUESTIONSTATE.WAITING;
                    currentQZone.GetComponent<QuestionZone>().SubmitAnswer(0, JoyStickNum - 1);

                    print("A");
                    
                    break;
                }
            case JOYSTICKBUTTON.FIRE:
                {
                    qstate = QUESTIONSTATE.WAITING;
                    currentQZone.GetComponent<QuestionZone>().SubmitAnswer(1, JoyStickNum - 1);

                    print("B");
                    
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

    public void Unlock()
    {
        if (qstate == QUESTIONSTATE.WAITING)
        {
            qstate = QUESTIONSTATE.NONE;
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

        if (aimVec != Vector3.zero)
        {
		    if(Time.time >= timeWhenFired + weapon.cooldown)
		    {
				latestAimingDirection = aimVec;

                weapon.Fire(gameObject, hand.position, new Vector2(latestAimingDirection.x, latestAimingDirection.y));		
			    timeWhenFired = Time.time;
		    }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "QuestionZones")
        {
            if (!other.gameObject.GetComponent<QuestionZone>().used)
            {
                if (qstate == QUESTIONSTATE.NONE)
                {
                    currentQZone = other.gameObject;

                    currentQZone.GetComponent<QuestionZone>().inited = true;
                    
                    qstate = QUESTIONSTATE.WAITING;
                }
            }
        }
        else if (other.gameObject.tag == "EndLevel")
        {
            Application.LoadLevel(4);
        }
    }

    public void AddScore(int p_score)
    {
        score += p_score;
        gtext.text = score.ToString();
    }
    public int GetScore()
    {
        return score;
    }
}
