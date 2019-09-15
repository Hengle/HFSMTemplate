using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1State : BaseState
{

    public override void OnStart()
    {
        StateID = eStateID.Attack1;
        AddTransition(eTransition.Attack1ToAttack2, eStateID.Attack2);
    }

    public override void OnEnter()
    {
        Debug.Log(StateControl.SharedData + "<color=red>" + StateID + "</color> ");
    }

    public override void OnAction()
    {
        
    }

    public override void OnExit(out object _send)
    {
        Debug.Log("Attack111111111111111111111111111111");
        _send = StateID;

        StateControl.ReceivedAction("This data is <color=red>" + StateID + "</color> send to ");

    }

    public override void OnDrive()
    {
       Control.PerformTransition(eTransition.Attack1ToAttack2);
    }
}
