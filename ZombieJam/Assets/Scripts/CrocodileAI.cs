using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrocodileAI : AISimple {

    protected enum STATE
    {
        RUNNINGLEFT,
        RUNNINGRIGHT,
        WALKINGLEFT,
        WALKINGRIGHT,
        IDLESTATE
    }

    public float changeTarget = 3.0f;

    private float timeWhenChange = 0.0f;
    private Vector3 currentDirection;

    private STATE state = STATE.IDLESTATE;
    protected STATE previousState = STATE.IDLESTATE;

    public void Start()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }

    public override void Move(Vector3 direction)
    {
        transform.position -= direction * Time.deltaTime * 0.1f;
    }

    public override void RunAI()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        Vector3 bestDirection = new Vector3(100, 100, 100);

        List<Vector3> dirs = new List<Vector3>();
        foreach (GameObject p in players)
        {
            Vector3 dir = transform.position - p.transform.position;
            //dirs.Add(dir);

            // Pick closest direction.
            if (dir.magnitude < bestDirection.magnitude)
            {
                bestDirection = dir;
            }
        }

        if (bestDirection.magnitude < 4.0f)
        {
            // Attack Attack!
            animation.CrossFade("AligatorAttacking", 0.3f);
        }
        else
        {
            // Move.
            animation.CrossFade("AligatorRunning", 0.3f);
        }

        /*
        // Change direction.
        if (Time.time >= timeWhenChange + changeTarget)
        {
            // Random player to move against.
            currentDirection = dirs[Random.Range(0, dirs.Count)];

            timeWhenChange = Time.time;
        }*/

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

        Move(new Vector3(bestDirection.x, 0.0f, 0.0f));
    }
}
