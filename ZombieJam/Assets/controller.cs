using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {

	public int JoyStickNum = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 deltaPos = new Vector3 (Input.GetAxis ("HorizontalLeft" + JoyStickNum.ToString()), Input.GetAxis ("VerticalLeft" + JoyStickNum.ToString()), 0 );
		Vector3 aimVec = new Vector3 (Input.GetAxis ("HorizontalRight" + JoyStickNum.ToString()), Input.GetAxis ("VerticalRight" + JoyStickNum.ToString()), 0 );

		if (Input.GetButtonDown ("Jump" + JoyStickNum.ToString())) 
		{
			GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));
		}

		if (Input.GetButtonDown ("Fire" + JoyStickNum.ToString())) 
		{
			print ("Fire!");
		}

		transform.position += deltaPos; 

	}
}
