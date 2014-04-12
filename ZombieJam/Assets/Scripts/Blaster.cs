using UnityEngine;
using System.Collections;

public class Blaster : Weapon {

	public GameObject bullet;

	public Blaster() : base(0.2f)
	{
		
	}

	public override void Fire (Vector2 playerPosition, Vector2 direction)
	{
		Vector2 spawnPosition = playerPosition + direction * 2;
		GameObject bulletImpl = Instantiate(bullet, spawnPosition, Quaternion.identity) as GameObject;	
		
		bulletImpl.GetComponent<Bullet>().SetDirection(direction);
	}
}
