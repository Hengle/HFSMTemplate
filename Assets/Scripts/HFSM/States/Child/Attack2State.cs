using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2State : BaseState
{

    public override void OnStart()
    {
        StateID = eStateID.Attack2;
        AddTransition(eTransition.Attack2ToAttack3, eStateID.Attack3);
    }

    public override void OnEnter()
    {
        Debug.Log(StateControl.SharedData + "<color=red>" + StateID + "</color> ");
    }

    public override void OnAction()
    {
        Control.PerformTransition(eTransition.Attack2ToAttack3);
    }

    public override void OnExit(out object _send)
    {
        _send = StateID;

        StateControl.ReceivedAction("This data is <color=red>" + StateID + "</color> send to ");
    }

    public override void OnDrive()
    {
        
    }
}
