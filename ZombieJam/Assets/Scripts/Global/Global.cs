using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

    public static int numberOfPlayers;
	// Use this for initialization
	void Start () {
        Application.LoadLevel(1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
       
    }
}
