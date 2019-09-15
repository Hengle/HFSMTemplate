using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{

    public override void OnStart()
    {
        StateID = eStateID.Idle;
        AddTransition(eTransition.IdleToMove, eStateID.Move);
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }
    public override void OnAction()
    {
         Control.PerformTransition(eTransition.IdleToMove);
    }

    public override void OnExit(out object _send)
    {
        _send = StateID;
    }

    public override void OnDrive()
    {
       
    }
}
