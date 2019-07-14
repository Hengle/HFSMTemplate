﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : BaseState
{
    BaseStateControl childStateControl;
    private void Start()
    {
        StateID = eStateID.Move;
        AddTransition(eTransition.MoveToAttack, eStateID.Attack);
    }

    public override void OnEnter(in object _receive)
    {
        Debug.Log("CurState is <color=red>" + StateID + "</color>, The last state I received was " + "<color=red>" + _receive + "</color>");
    }

    public override void OnExit(out object _send)
    {
        _send = StateID;
    }

    public override void OnDrive()
    {
        Control.PerformTransition(eTransition.MoveToAttack);
    }
}
