using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack3State : BaseState
{

    public override void OnStart()
    {
        StateID = eStateID.Attack3;
    }

    public override void OnEnter()
    {
        Debug.Log(StateControl.SharedData + "<color=red>" + StateID + "</color> ");
    }

    public override void OnAction()
    {
        base.OnAction();
    }

    public override void OnExit(out object _send)
    {
        _send = null;

        StateControl.ReceivedAction("This data is <color=red>" + StateID + "</color> send to ");
    }
}
