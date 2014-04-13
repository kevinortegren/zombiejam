using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AISimple : MonoBehaviour {

    protected Vector3 bestDirection;
    protected GameObject target;

    // Not implemented.
    public float reach = 0.0f;

    public bool guard = false;
    public float speed = 0.1f;
	public float shootRange = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        RunAI();
	}

    public virtual void RunAI()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length == 0)
            return;

        GameObject targetPlayer = null;
        Vector3 direction = new Vector3(100, 100, 100);

        List<Vector3> dirs = new List<Vector3>();
        foreach (GameObject p in players)
        {
            Vector3 dir = transform.position - p.transform.position;
            //dirs.Add(dir);

            // Pick closest direction.
            if (dir.magnitude < direction.magnitude)
            {
                print("New Target " + p.GetComponent<Player>().JoyStickNum);
                direction = dir;
                targetPlayer = p;
            }
        }

        target = targetPlayer;
        bestDirection = direction;

		if (!guard && bestDirection.magnitude < shootRange)
        {

            // Call move.
            Move();

        }
        else
        {
            Idle();
        }

    }

    public virtual void Move() { }

    public virtual void Idle() { }
}
