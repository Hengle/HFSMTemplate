using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2State : BaseState
{

    private void Start()
    {
        StateID = eStateID.Attack2;
        AddTransition(eTransition.Attack2ToAttack3, eStateID.Attack3);
    }

    public override void OnEnter()
    {
        Debug.Log(Control.SharedData + "<color=red>" + StateID + "</color> ");
    }

    public override void OnExit(out object _send)
    {
        _send = StateID;
        Control.ReceiveData = "This data is <color=red>" + StateID + "</color> send to ";
    }

    public override void OnDrive()
    {
        Control.PerformTransition(eTransition.Attack2ToAttack3);
    }
}
