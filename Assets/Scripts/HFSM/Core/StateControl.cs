using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateControl : MonoBehaviour
{

    public static object SharedData { get; set; }
    public static Action<object> ReceivedAction { get; set; }
    public StateSystem StateSystem { get; set; }

    private UnityEnumEvent onStateChangedEvent;

    /// <summary>
    /// 此事件仅监听改变后的事件
    /// </summary>
    /// <param name="action"></param>
    public void AddStateChangedListener(UnityAction<eStateID> action)
    {
        onStateChangedEvent.RemoveListener(action);
        onStateChangedEvent.AddListener(action);
    }

    public void RemoveStateChangedListener(UnityAction<eStateID> action)
    {
        onStateChangedEvent.RemoveListener(action);
    }

    private void Awake()
    {
        StateSystem = new StateSystem();
        onStateChangedEvent = new UnityEnumEvent();
        InitState();
    }

    public void InitState()
    {
        BaseState baseState;
        for (int i = 0; i < transform.childCount; i++)
        {
            baseState = transform.GetChild(i).GetComponent<BaseState>();
            baseState.Control = this;
            baseState.OnStart();
            StateSystem.AddState(baseState);
        }
        BaseState firstState = transform.GetChild(0).GetComponent<BaseState>();
        ForceSetCurState(firstState);
    }
    /// <summary>
    /// 执行状态转换条件
    /// </summary>
    /// <param name="trans">转换条件</param>
    public virtual void PerformTransition(eTransition trans)
    {
        StateSystem.PerformTransition(trans);
        onStateChangedEvent.Invoke(StateSystem.CurStateID);
    }
    /// <summary>
    /// 强制更改当前状态
    /// </summary>
    /// <param name="state">更改后的状态</param>
    public void ForceSetCurState(BaseState state)
    {
        StateSystem.SetCurState(state);
    }

    public void Update()
    {
        Debug.LogError("<color=green>CurState---> " + StateSystem.CurState + "</color>");
        StateSystem.CurState.OnDrive();
        StateSystem.CurState.OnUpdate();
    }
}

public class UnityEnumEvent : UnityEvent<eStateID> { }