using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrocodileAI : AISimple {

    protected enum STATE
    {
        WALKINGLEFT,
        WALKINGRIGHT
    }

    public float changeTarget = 3.0f;
    private Vector3 currentDirection;

    private STATE state = STATE.WALKINGLEFT;
    protected STATE previousState = STATE.WALKINGLEFT;

    public void Start()
    {
       
    }

    public override void Move()
    {
        if (bestDirection.magnitude < 4.0f)
        {
            // Attack Attack!
            animation.CrossFade("AligatorAttacking", 0.3f);

            target.GetComponent<Life>().TakeDamage(0.5f);
        }
        else
        {
            // Move.
            animation.CrossFade("AligatorRunning", 0.3f);
        }

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

        transform.position -= bestDirection * Time.deltaTime * speed;
    }

    public override void RunAI()
    {
        base.RunAI();

        /*
        // Change direction.
        if (Time.time >= timeWhenChange + changeTarget)
        {
            // Random player to move against.
            currentDirection = dirs[Random.Range(0, dirs.Count)];

            timeWhenChange = Time.time;
        }*/
    }
}
