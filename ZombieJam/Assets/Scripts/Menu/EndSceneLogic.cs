using UnityEngine;
using System.Collections;

public class EndSceneLogic : MonoBehaviour {

    public GameObject guitext;
    private GUIText gtext;

	// Use this for initialization
	void Start () {

        foreach (Player playah in Global.playerList)
        {
            GameObject gobject = (GameObject)Instantiate(guitext, transform.position, transform.rotation);
            gtext = gobject.GetComponent<GUIText>(); 
            gtext.anchor = TextAnchor.MiddleCenter;
            gtext.transform.position = new Vector3(0.5f, 0.15f * (float)(playah.JoyStickNum - 1.0f) + 0.5f, 0.0f);
            gtext.color = playah.privColor;
            gtext.text = "Score: " + playah.GetScore();
        }
      
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
