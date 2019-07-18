using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1State : BaseState
{

    private void Start()
    {
        StateID = eStateID.Attack1;
        AddTransition(eTransition.Attack1ToAttack2, eStateID.Attack2);
    }

    public override void OnEnter()
    {
        Debug.Log(NodeStateControl.SharedData + "<color=red>" + StateID + "</color> ");
    }

    public override void OnExit(out object _send)
    {
        _send = StateID;

        NodeStateControl.ReceivedAction("This data is <color=red>" + StateID + "</color> send to ");

    }

    public override void OnDrive()
    {
        Control.PerformTransition(eTransition.Attack1ToAttack2);
    }
}
