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

        RunAI();
	}

    public virtual void RunAI() {}

    public virtual void Move(Vector3 direction) { }

    public virtual void Shoot(Vector2 direction)
    {
        Weapon wc = weapon.GetComponent<Weapon>();
        if (Time.time >= timeWhenFired + aiCooldown)
        {
            wc.Fire(gameObject, transform.position, new Vector2(-direction.x, -direction.y));
            timeWhenFired = Time.time;
        }
    }
}
