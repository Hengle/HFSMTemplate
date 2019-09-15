using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSystem
{
    public eStateID CurStateID { get; private set; }
    public BaseState CurState { get; set; }
    List<BaseState> stateList = new List<BaseState>();

    public virtual void AddState(BaseState state)
    {
        //添加的第一个状态是默认状态
        if (stateList.Count == 0)
        {
            CurState = state;
            stateList.Add(state);
            return;
        }
        if (stateList.Contains(state)) return;
        stateList.Add(state);
    }

    public virtual void RemoveState(BaseState state)
    {
        if (!stateList.Contains(state)) return;
        stateList.Remove(state);
    }

    public void SetCurState(BaseState state)
    {
        object data = null;
        state.OnEnter();
        state.OnEnter(in data);
        state.OnAction();
        CurState = state;
    }

    public virtual void PerformTransition(eTransition trans)
    {
        Debug.Log("CurState " + CurState.name);
        eStateID id = CurState.GetStateIDByTrans(trans);

        if (id == eStateID.Null)
        {
            Debug.LogError("ERROR: CurrentState " + CurStateID + " TargetState " + id + " Transition " + trans);
            return;
        }
        CurStateID = id;
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
