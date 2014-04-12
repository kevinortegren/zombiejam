using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

    public GameObject trap;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        trap.GetComponent<SpawnEnemy>().Trigger();
    }
}
