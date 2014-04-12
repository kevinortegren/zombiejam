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

	protected Vector3 aimVec;

	// Use this for initialization
	void Start () {
	
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
				ProcessState (STATE.RUNNINGRIGHT);
			}
			else
			{
				ProcessState (STATE.WALKINGRIGHT);
			}
		} 
		else if (deltaPos.x < 0.0) 
		{
			if(deltaPos.x < -0.1)
			{
				ProcessState (STATE.RUNNINGLEFT);
			}
			else
			{
				ProcessState ( STATE.WALKINGLEFT);
			}
		}
		else 
		{
			ProcessState (STATE.IDLESTATE);
		}

		if (Input.GetButtonDown ("Jump" + JoyStickNum.ToString())) 
		{
			ProcessInput(JOYSTICKBUTTON.JUMP);
		}

		if (Input.GetButtonDown ("Fire" + JoyStickNum.ToString())) 
		{
			ProcessInput(JOYSTICKBUTTON.FIRE);
		}

		transform.position += deltaPos; 
	}

	protected virtual void ProcessInput(JOYSTICKBUTTON button) {}

	protected virtual void ProcessState(STATE State) {}
}
