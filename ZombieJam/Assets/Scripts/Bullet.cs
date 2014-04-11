using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Vector2 direction = new Vector2(1,0);

	public void SetDirection(Vector2 direction)
	{
		this.direction = direction;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 temp = transform.position;
		//print("X: " + direction.x + " Y: " + direction.y);
	
		temp.x += direction.x * 0.1f;
		temp.y += direction.y * 0.1f;
		
		transform.position = temp;
	
	}
}
