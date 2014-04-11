using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Vector3 velocity;

	// Use this for initialization
	void Start () {
	
		velocity = new Vector3(0.1f, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position += velocity;
	
	}
}
