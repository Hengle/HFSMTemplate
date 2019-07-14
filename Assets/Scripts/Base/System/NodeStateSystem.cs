using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeStateSystem
{
    public eStateID CurStateID { get; private set; }
    public BaseState CurState { get; set; }
    List<BaseState> stateList = new List<BaseState>();
    BaseState parentState;

    public void AddState(BaseState state)
    {
        //添加的第一个状态是默认状态
        if (stateList.Count == 0)
        {
            object data = null;
            //手动执行添加的第一个状态中的Enter、Action方法
            state.OnEnter();
            state.OnEnter(in data);
            state.OnAction();
            CurState = state;
            stateList.Add(state);
            return;
        }
        if (stateList.Contains(state)) return;
        stateList.Add(state);
    }

    public void AddState(BaseState state, BaseState parentState)
    {
        this.parentState = parentState;
        //添加的第一个状态是默认状态
        if (stateList.Count == 0)
        {
            object data = null;
            //手动执行添加的第一个状态中的Enter、Action方法
            state.OnEnter();
            state.OnEnter(in data);
            state.OnAction();
            CurState = state;
            stateList.Add(state);
            return;
        }
        if (stateList.Contains(state)) return;
        stateList.Add(state);
    }

    public void RemoveState(BaseState state)
    {
        if (!stateList.Contains(state)) return;
        stateList.Remove(state);
    }

    public void PerformTransition(eTransition trans)
    {
        CurStateID = CurState.GetStateIDByTrans(trans);
        foreach (var state in stateList)
        {
            if (state.StateID == CurStateID)
            {
                CurState.OnExit();
                CurState.OnExit(out object dataNext);
                CurState = state;
                CurState.OnEnter();
                CurState.OnEnter(in dataNext);
                CurState.OnAction();
            }
        }
    }
}
