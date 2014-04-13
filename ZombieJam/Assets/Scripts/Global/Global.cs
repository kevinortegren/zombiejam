using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Global : MonoBehaviour {

    public static int numberOfPlayers;

    public static List<Player> playerList = new List<Player>();

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
