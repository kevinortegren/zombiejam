using UnityEngine;
using System.Collections;
using System;

public class DownButton : Button {

    public GameObject numberThing;
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void OnClicked()
    {
        int currNum = Convert.ToInt32(numberThing.GetComponent<TextMesh>().text);
        currNum--;
        if(currNum > 0)
            numberThing.GetComponent<TextMesh>().text = currNum.ToString();
        base.OnClicked();
    }
}
