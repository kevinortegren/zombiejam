using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Vector2 direction = new Vector2(1,0);
	public float force = 1000.0f;
    public float lifetime = 10.0f;
    
    private float aliveTime = 0.0f;

	public void Launch(Vector2 direction)
	{
		GetComponent<Rigidbody2D>().AddForce(direction * force);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        aliveTime += Time.deltaTime;

        if (aliveTime > lifetime)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
