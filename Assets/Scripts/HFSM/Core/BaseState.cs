using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eStateID
{
    //State
    Idle = 0,
    Move,
    Attack,

    //ChildState
    Attack1,
    Attack2,
    Attack3,
}

public enum eTransition
{
    //Transition
    IdleToMove = 0,
    MoveToAttack,
    //AttackToIdle,

    //ChildTransition
    Attack1ToAttack2,
    Attack2ToAttack3,
    //Attack3ToAttack1,

}

public abstract class BaseState : MonoBehaviour
{
    /// <summary>
    /// 设置状态的ID
    /// </summary>
    public eStateID StateID { get; set; }

    public BaseStateControl Control { get; set; }

    public object ReceivedData { get; set; }

    Dictionary<eTransition, eStateID> StateDic = new Dictionary<eTransition, eStateID>();

    public void AddTransition(eTransition _trans, eStateID _id)
    {
        if (StateDic.ContainsKey(_trans)) return;
        StateDic.Add(_trans, _id);
    }

    public void RemoveTransition(eTransition _trans)
    {
        if (StateDic.ContainsKey(_trans))
        {
            StateDic.Remove(_trans);
        }
    }

    public eStateID GetStateIDByTrans(eTransition trans)
    {
        if (StateDic.ContainsKey(trans))
        {
            return StateDic[trans];
        }
        Debug.LogFormat("GetStateIDByTrans---> {0} {1}", StateID, trans);
        return eStateID.Idle;
    }

    public virtual void OnEnter() { }
    //接收上一个状态的信息
    public virtual void OnEnter(in object _receive) { }

    public virtual void OnAction() { }

    public virtual void OnExit() { }
    //发送信息到下一个状态
    public virtual void OnExit(out object _send) { _send = null; }

    public virtual void OnDrive() { }

    public virtual void OnUpdate() { }

}
