using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OpponentState
{
    protected OpponentStateMachine stateMachine;


    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();

    public OpponentState(OpponentStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
}
