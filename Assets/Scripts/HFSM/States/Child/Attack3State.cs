using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack3State : BaseState
{

    private void Start()
    {
        StateID = eStateID.Attack3;
    }

    public override void OnEnter()
    {
        Debug.Log(NodeStateControl.SharedData + "<color=red>" + StateID + "</color> ");
    }

    public override void OnExit(out object _send)
    {
        _send = null;

        NodeStateControl.ReceivedAction("This data is <color=red>" + StateID + "</color> send to ");
    }
}
