using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeStateControl : BaseStateControl
{
    public static object SharedData { get; set; }
    public static Action<object> ReceivedAction { get; set; }

    public override void InitState()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            BaseState baseState = transform.GetChild(i).GetComponent<BaseState>();
            baseState.Control = this;
            stateSystem.AddState(baseState, transform.GetComponent<BaseState>());
        }
    }
}
