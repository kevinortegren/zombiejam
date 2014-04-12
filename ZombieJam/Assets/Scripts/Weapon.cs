using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float cooldown;
    public float collisionDamage;
    public float collisionCooldown;
	
	public Weapon(float cooldown, float collisionDamage, float collisionCooldown)
	{
		this.cooldown = cooldown;
        this.collisionDamage = collisionDamage;
        this.collisionCooldown = collisionCooldown;
	}

    public virtual void setPositionAtHand()
    {
    }
	
	public virtual void Fire(GameObject owner, Vector3 playerPosition, Vector2 direction) {}

}
