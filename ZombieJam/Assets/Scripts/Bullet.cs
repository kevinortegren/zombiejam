using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Vector2 direction = new Vector2(1,0);
	public float force = 1000.0f;
    public float lifetime = 10.0f;
    public float damage = 30.0f;
    
    private float aliveTime = 0.0f;
    private GameObject owner;

	public void Launch(GameObject owner, Vector2 direction)
	{
        this.owner = owner;
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

    void OnCollisionEnter2D(Collision2D other)
    {
        // Do not collide with self.
        if (other.gameObject.tag != owner.tag)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<Life>().TakeDamage(damage);
                owner.GetComponent<Player>().AddScore(2);
            }
            else if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Player>().AddScore(-10);
            }
            Destroy(gameObject);
        }
    }
}
