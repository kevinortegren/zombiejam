using UnityEngine;
using System.Collections;

public class AISimple : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject p in players)
        {
            Vector3 dir = transform.position - p.transform.position;
            print("testing player");

            if (Physics.Raycast(transform.position, dir))
            {
                print("hit!");
            }
            
        }

        


	}
}
