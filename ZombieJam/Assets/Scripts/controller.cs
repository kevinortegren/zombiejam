using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {

	protected enum JOYSTICKBUTTON
	{
		FIRE,
		JUMP,
	}
	
	protected enum STATE
	{
		RUNNINGLEFT,
		RUNNINGRIGHT,
		WALKINGLEFT,
		WALKINGRIGHT,
		IDLESTATE
	}
	
	public int JoyStickNum = 0;

	protected STATE previousState = STATE.RUNNINGRIGHT;
    protected STATE currentState = STATE.RUNNINGRIGHT;

	protected Vector3 aimVec;

	// Use this for initialization
	void Start () {
	
	}

    protected void UpdateQuestionInput()
    {
        if (Input.GetButtonDown("Jump" + JoyStickNum.ToString()))
        {
            ProcessQuestionInput(JOYSTICKBUTTON.JUMP);
        }

        if (Input.GetButtonDown("Fire" + JoyStickNum.ToString()))
        {
            ProcessQuestionInput(JOYSTICKBUTTON.FIRE);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ProcessQuestionInput(JOYSTICKBUTTON.FIRE);
        }
    }

	// Update is called once per frame
	protected void UpdateInput () {

		Vector3 deltaPos = new Vector3 (Input.GetAxis ("HorizontalLeft" + JoyStickNum.ToString()), 0, 0 );
		aimVec = new Vector3 (Input.GetAxis ("HorizontalRight" + JoyStickNum.ToString()), Input.GetAxis ("VerticalRight" + JoyStickNum.ToString()), 0 );
		aimVec = Vector3.Normalize(aimVec);

		if (deltaPos.x > 0.0)
		{
			if(deltaPos.x > 0.1)
			{
                currentState = STATE.RUNNINGRIGHT;

				//ProcessState (STATE.RUNNINGRIGHT);
			}
			else
			{
                currentState = STATE.WALKINGRIGHT;

				//ProcessState (STATE.WALKINGRIGHT);
			}
		} 
		else if (deltaPos.x < 0.0) 
		{
			if(deltaPos.x < -0.1)
			{
                currentState = STATE.RUNNINGLEFT;

				//ProcessState (STATE.RUNNINGLEFT);
			}
			else
			{
                currentState = STATE.WALKINGLEFT;

				//ProcessState ( STATE.WALKINGLEFT);
			}
		}
		else 
		{
            currentState = STATE.IDLESTATE;

			//ProcessState (STATE.IDLESTATE);
		}

		if (Input.GetButtonDown ("Jump" + JoyStickNum.ToString())) 
		{
			ProcessInput(JOYSTICKBUTTON.JUMP);
		}

		if (Input.GetButtonDown ("Fire" + JoyStickNum.ToString())) 
		{
			ProcessInput(JOYSTICKBUTTON.FIRE);
		}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ProcessInput(JOYSTICKBUTTON.FIRE);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            deltaPos.x += 0.1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            deltaPos.x -= 0.1f;
        }

		transform.position += deltaPos;

        ProcessState();
	}

	protected virtual void ProcessInput(JOYSTICKBUTTON button) {}
    protected virtual void ProcessQuestionInput(JOYSTICKBUTTON button) { }

	protected virtual void ProcessState() {}
}
