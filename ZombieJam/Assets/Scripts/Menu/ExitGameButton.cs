using UnityEngine;
using System.Collections;

public class ExitGameButton : Button {

    // Use this for initialization
    void Start()
    {
        Global.playerList.Clear();
        Global.numberOfPlayers = 0;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void OnClicked()
    {
        base.OnClicked();
    }
}
