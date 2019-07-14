
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RootStateControl : BaseStateControl
{
    
    public override void InitState()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            BaseState baseState = transform.GetChild(i).GetComponent<BaseState>();
            baseState.Control = this;
            stateSystem.AddState(baseState);
        }
    }
}

