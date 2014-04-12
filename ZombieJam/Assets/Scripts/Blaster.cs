using UnityEngine;
using System.Collections;

public class Blaster : Weapon {

    public GameObject bullet;

	public Blaster() : base(0.2f)
	{
		
	}

    public override void Fire(GameObject owner, Vector3 playerPosition, Vector2 direction)
	{
        GameObject bulletImpl = Instantiate(bullet, playerPosition, Quaternion.identity) as GameObject;

        //bulletImpl.GetComponent<Rigidbody2D>().AddForceAtPosition(direction * 4000.0f, new Vector2(playerPosition.x, playerPosition.y));
        bulletImpl.GetComponent<Bullet>().Launch(owner, direction);

		//bulletImpl.GetComponent<Bullet>().SetDirection(direction);
	}
}
