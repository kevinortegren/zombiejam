using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	public float health = 100;
    public GameObject gameObj;

	// Use this for initialization
	void Start () {

	}

    public void TakeDamage(float health)
    {
        this.health -= health;
        //print(gameObject.name + " " + this.health + " hp.");
        
    }

	// Update is called once per frame
	void Update () {
		if(health < 0.0f)
		{
			Die();
		}
	}

	public void Die()
	{
        if (!(gameObject.tag == "Player"))
        {
            Instantiate(gameObj, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
	}
}
