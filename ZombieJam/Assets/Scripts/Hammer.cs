using UnityEngine;
using System.Collections;

public class Hammer : Weapon
{
    public const string weaponPrefab = "Hammer";
	public Hammer() : base(0.0f, 50.0f, 0.5f)
	{
         
	}

    public override void setPositionAtHand()
    {
        transform.localPosition = new Vector3(0, 0.0045f, -0.014f);
        transform.localRotation = Quaternion.Euler(new Vector3(-90, 0, 0));
    }

    public override void Fire(GameObject owner, Vector3 playerPosition, Vector2 direction)
	{
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //to do: timer for cooldown
            collision.gameObject.GetComponent<Life>().TakeDamage(collisionDamage);
        }
    }
}