using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{

    private void Start()
    {
        StateID = eStateID.Idle;
        AddTransition(eTransition.IdleToMove, eStateID.Move);
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit(out object _send)
    {
        _send = StateID;
    }

    public override void OnDrive()
    {
        Control.PerformTransition(eTransition.IdleToMove);
    }
}
