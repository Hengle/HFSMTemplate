using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    BaseStateControl childStateControl = null;
    private void Start()
    {
        StateID = eStateID.Attack;

        childStateControl = gameObject.AddComponent<NodeStateControl>();
        childStateControl.enabled = false;
    }
    public override void OnEnter(in object _receive)
    {
        Debug.Log("CurState is <color=red>" + StateID + "</color>, The last state I received was " + "<color=red>" + _receive + "</color>");
        childStateControl.enabled = true;
        //分享数据给子状态机控制器
        NodeStateControl.SharedData = "This data is <color=red>" + StateID + "</color> to ";

        NodeStateControl.ReceivedAction = new System.Action<object>(ABC);
    }

    public override void OnExit(out object _send)
    {
        _send = null;
        childStateControl.enabled = false;
    }

    public override void OnUpdate()
    {
        //接收从子状态传递给子状态控制器的数据
        //Debug.Log(childStateControl.ReceiveData + "<color=red>" + StateID + "</color>");
    }

    void ABC(object _data)
    {
        Debug.Log(_data + "<color=red>" + StateID + "</color>");
    }
}
