using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public StateControl Control;
    // OnStart is called before the first frame update
    void Start()
    {
        Control.AddStateChangedListener(ABC);
    }

    void ABC(eStateID stateID)
    {
        if (stateID == eStateID.Attack2)
        {
            Debug.Log("666");
        }
        Debug.Log("HAHHAHAHHAHHAHA--->" + stateID);
    }

    private void Update()
    {
        if (Control != null)
        {
            Debug.Log("999 " + Control.StateSystem.CurStateID);
        }
    }
}
