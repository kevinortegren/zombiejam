using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	public float health = 100;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(health < 0.0f)
		{
			Die();
		}
	}

	void Die()
	{

	}
}
