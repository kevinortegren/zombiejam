using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

    public Player player;
	// Use this for initialization
	void Start () {

        if (Global.numberOfPlayers <= 0)
        {
            Player playerObj = (Player)Instantiate(player, transform.position, transform.rotation);
            playerObj.GetComponent<Player>().JoyStickNum = 1;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().target = playerObj.transform;
        }
        else
        {
            for (int i = 0; i < Global.numberOfPlayers; ++i)
            {
                Player playerObj = (Player)Instantiate(player, transform.position, transform.rotation);
                playerObj.GetComponent<Player>().JoyStickNum = i + 1;

                if(i == 0)
                     GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().target = playerObj.transform;
            }
        }

       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
