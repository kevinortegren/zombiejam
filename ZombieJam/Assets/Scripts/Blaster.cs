using UnityEngine;
using System.Collections;

public class Blaster : Weapon {

    public GameObject bullet;

	public Blaster() : base(0.2f, 0.0f, 0.0f)
	{

	}

    public override void setPositionAtHand()
    {
        transform.localPosition = new Vector3(0.002f, 0.002f, -0.001f);
        transform.localRotation = Quaternion.Euler(new Vector3(-90, 0, 0));
    }

    public override void Fire(GameObject owner, Vector3 playerPosition, Vector2 direction)
	{
        GameObject bulletImpl = Instantiate(bullet, playerPosition, Quaternion.identity) as GameObject;

        //bulletImpl.GetComponent<Rigidbody2D>().AddForceAtPosition(direction * 4000.0f, new Vector2(playerPosition.x, playerPosition.y));
        bulletImpl.GetComponent<Bullet>().Launch(owner, direction);

		//bulletImpl.GetComponent<Bullet>().SetDirection(direction);
	}
}
