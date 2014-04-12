using UnityEngine;
using System.Collections;
using System;

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

    Quaternion currentAim = Quaternion.identity;

    private Transform shoulder;
    private Transform hand;

    public void Start()
    {
        transform.Rotate(new Vector3(0, 180, 0));

        Transform[] joints = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform t in joints)
        {
            if (t.name == "Blaster")
            {
                print(gameObject.name + " blaster");
                hand = t.GetChild(0);
            }

            if (t.name == "RightShoulder")
            {
                print(gameObject.name + " shoulder");
                shoulder = t;
            }
        }
    }

    public override void RunAI()
    {
        base.RunAI();

        bestDirection = Vector3.Normalize(new Vector3(bestDirection.x, bestDirection.y, 0.0f));

        RotateArm();

        Shoot();
    }

    void RotateArm()
    {
        if (bestDirection != Vector3.zero)
        {
            float angle = (float)Math.Atan2(-bestDirection.y, -bestDirection.x) * Mathf.Rad2Deg;

            Quaternion newAim = Quaternion.Euler(new Vector3(0, 0, angle));
            currentAim = Quaternion.Slerp(this.currentAim, newAim, 0.2f);

            shoulder.rotation = currentAim;
        }
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
            wc.Fire(gameObject, hand.position, new Vector2(-bestDirection.x, -bestDirection.y));
            timeWhenFired = Time.time;
        }
    }
}
