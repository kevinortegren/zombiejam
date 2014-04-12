using UnityEngine;
using System.Collections;
using System;

public class NumberSelectButton : HorizontalButton {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void OnLeft()
    {
        int currNum = Convert.ToInt32(GetComponent<TextMesh>().text);
        currNum--;
        if (currNum > 0)
        {
            GetComponent<TextMesh>().text = currNum.ToString();
            Global.numberOfPlayers = currNum;
        }
        base.OnLeft();
    }

    protected override void OnRight()
    {
        int currNum = Convert.ToInt32(GetComponent<TextMesh>().text);
        currNum++;
        if (currNum < 10)
        {
            GetComponent<TextMesh>().text = currNum.ToString();
            Global.numberOfPlayers = currNum;
        }
        base.OnRight();
    }
}
