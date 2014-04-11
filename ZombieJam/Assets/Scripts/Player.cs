using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

	private float timeWhenFired = 0.0f;
	public GameObject activeWeapon;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// Temp movement.
		if(Input.GetKey(KeyCode.RightArrow))
			GetComponent<CharacterController>().Move(new Vector3(1,0,0) * 0.1f);
		else if(Input.GetKey(KeyCode.LeftArrow))
			GetComponent<CharacterController>().Move(-Vector3.right * 0.1f);
		
		// Shoot logic.
		if(Input.GetKey(KeyCode.Space))
		{
			Shoot();
		}
		
		// Level bounds check.
		Vector3 position = transform.position;
		if(position.x < Level.LevelWidth && position.x > 0 
			&& position.y > 0 && position.y < Level.LevelHeight)
		{
				
		}
	}
	
	void Shoot()
	{
		Weapon weapon = activeWeapon.GetComponent<Weapon>();
	
		if(Time.time >= timeWhenFired + weapon.cooldown)
		{
			weapon.Fire(transform.position);		
			timeWhenFired = Time.time;
		}
	}
}
