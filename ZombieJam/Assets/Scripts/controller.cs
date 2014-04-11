using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {

	protected enum JOYSTICKBUTTON
	{
		FIRE,
		JUMP
	}
	public int JoyStickNum = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected void UpdateInput () {

		Vector3 deltaPos = new Vector3 (Input.GetAxis ("HorizontalLeft" + JoyStickNum.ToString()), 0, 0 );
		Vector3 aimVec = new Vector3 (Input.GetAxis ("HorizontalRight" + JoyStickNum.ToString()), Input.GetAxis ("VerticalRight" + JoyStickNum.ToString()), 0 );

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
}
