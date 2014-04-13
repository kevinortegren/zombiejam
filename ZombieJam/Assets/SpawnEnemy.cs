using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

    public GameObject enemyType;
    public int count;

    public void Trigger()
    {
        print("asd");
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemyType, transform.position, Quaternion.identity);
        }
    }

    // Use this for initialization
    void Start()
    {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
