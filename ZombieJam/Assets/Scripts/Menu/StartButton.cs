using UnityEngine;
using System.Collections;

public class StartButton : Button {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void OnClicked()
    {
        Application.LoadLevel(3);
        base.OnClicked();
    }
}
