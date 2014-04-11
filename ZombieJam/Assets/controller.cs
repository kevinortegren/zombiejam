using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {

	public int JoyStickNum;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 deltaPos = new Vector3(0,0,0);

		switch (JoyStickNum) {
			case 1:
			{
				deltaPos = new Vector3 (Input.GetAxis ("HorizontalLeft1"), Input.GetAxis ("VerticalLeft1"), 0 );
				break;
			}
			case 2:
			{
				deltaPos = new Vector3 (Input.GetAxis ("HorizontalLeft2"), Input.GetAxis ("VerticalLeft2"), 0 );
				break;
			}
			case 3:
			{
				deltaPos = new Vector3 (Input.GetAxis ("HorizontalLeft3"), Input.GetAxis ("VerticalLeft3"), 0 );
				break;
			}
			case 4:
			{
				deltaPos = new Vector3 (Input.GetAxis ("HorizontalLeft4"), Input.GetAxis ("VerticalLeft4"), 0 );
				break;
			}
			default:
				break;

		}

		if (Input.GetButtonDown ("Jump")) 
		{
			print("button Working");		
		}

		GetComponent<CharacterController> ().Move (deltaPos); 

	}
}
