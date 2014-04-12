using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AISimple : MonoBehaviour {

    public GameObject weapon;

    public float aiCooldown = 1.0f;

    private float timeWhenFired = 0.0f;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        List<Vector3> dirs = new List<Vector3>();

        foreach(GameObject p in players)
        {
            Vector3 dir = transform.position - p.transform.position;
            dirs.Add(dir);   
        }

        int i = Random.Range(0, dirs.Count);

        Vector2 asd = dirs[i];

        Shoot(new Vector2(dirs[i].x, dirs[i].y));

        Move(new Vector3(asd.x, asd.y, 0.0f));
	}

    void Move(Vector3 direction)
    {
        transform.position -= direction * Time.deltaTime * 0.1f;
    }

    void Shoot(Vector2 direction)
    {
        Weapon wc = weapon.GetComponent<Weapon>();
        if (Time.time >= timeWhenFired + aiCooldown)
        {
            wc.Fire(transform.position, new Vector2(-direction.x, -direction.y));
            timeWhenFired = Time.time;
        }
    }
}
