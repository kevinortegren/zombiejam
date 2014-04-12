using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AISimple : MonoBehaviour {

    protected Vector3 bestDirection;
    protected GameObject target;
    
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

        GameObject targetPlayer = players[0];
        Vector3 direction = new Vector3(100, 100, 100);

        List<Vector3> dirs = new List<Vector3>();
        foreach (GameObject p in players)
        {
            Vector3 dir = transform.position - p.transform.position;
            //dirs.Add(dir);

            // Pick closest direction.
            if (dir.magnitude < direction.magnitude)
            {
                direction = dir;
                targetPlayer = p;
            }
        }

        target = targetPlayer;
        bestDirection = direction;

        // Call move.
        Move();
    }

    public virtual void Move() { }


}
