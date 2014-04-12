using UnityEngine;
using System.Collections;

public class BadGuyAI : AISimple {

    protected enum STATE
    {
        WALKINGLEFT,
        WALKINGRIGHT,
        IDLE
    }

    public GameObject activeWeapon;

    private float timeWhenFired = 0.0f;
    private float aiCooldown = 1.0f;

    private STATE state = STATE.IDLE;

    public void Start()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }

    public override void RunAI()
    {
        base.RunAI();

        Shoot();
    }

    public override void Move()
    {
        animation.CrossFade("BadGuyWalking", 0.3f);

        // Moving x.
        if (bestDirection.x > 0)
        {
            if (state != STATE.WALKINGLEFT)
            {
                transform.Rotate(new Vector3(0, 180, 0));
            }

            state = STATE.WALKINGLEFT;
        }
        else
        {
            if (state != STATE.WALKINGRIGHT)
            {
                transform.Rotate(new Vector3(0, 180, 0));
            }

            state = STATE.WALKINGRIGHT;
        }

        transform.position -= bestDirection * Time.deltaTime * 0.1f;
    }

    public void Shoot()
    {
        Weapon wc = activeWeapon.GetComponent<Weapon>();
        if (Time.time >= timeWhenFired + aiCooldown)
        {
            wc.Fire(gameObject, transform.position, new Vector2(-bestDirection.x, -bestDirection.y));
            timeWhenFired = Time.time;
        }
    }
}
