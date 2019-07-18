using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseStateControl : MonoBehaviour
{

    /// <summary>
    /// 父状态分享数据给其所有子状态
    /// </summary>
    //public object SharedData { get; set; }
    /// <summary>
    /// 子状态返回数据给其父状态
    /// </summary>
    //public object ReceiveData { get; set; }

    public StateSystem stateSystem = null;
    private static UnityEnumEvent OnStateChangedEvent = null;

    public static void AddStateChangedListener(UnityAction<eStateID> action)
    {
        OnStateChangedEvent.RemoveListener(action);
        OnStateChangedEvent.AddListener(action);
    }

    public static void RemoveStateChangedListener(UnityAction<eStateID> action)
    {
        OnStateChangedEvent.RemoveListener(action);
    }

    private void Start()
    {
        stateSystem = new StateSystem();
        OnStateChangedEvent = new UnityEnumEvent();
        InitState();
    }

    public abstract void InitState();

    public void PerformTransition(eTransition trans)
    {
        stateSystem.PerformTransition(trans);
        OnStateChangedEvent.Invoke(stateSystem.CurStateID);
    }

    void Update()
    {
        //Debug.LogError("<color=green>CurState---> " + stateSystem.CurState + "</color>");
        stateSystem.CurState.OnDrive();
        stateSystem.CurState.OnUpdate();
    }
}

public class UnityEnumEvent : UnityEvent<eStateID> { }