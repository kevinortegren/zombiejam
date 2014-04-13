using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

    public GameObject enemyType;
    public int count;

    public void Trigger()
    {
        for (int i = 0; i < count; i++)
        {
			GameObject enemy = Instantiate(enemyType, transform.position + new Vector3(Random.Range(-2, 2), 0, 0), transform.rotation) as GameObject;

            enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1000, 1000), 0));
        }
    }

    // Use this for initialization
    void Start() {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
