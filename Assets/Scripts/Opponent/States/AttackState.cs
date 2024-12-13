using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : OpponentState
{
    
    public override void EnterState()
    {

    }

    
    public override void UpdateState()
    {
       
        float direction = Mathf.Sign(stateMachine.ballTransform.position.x - stateMachine.transform.position.x);

        
        stateMachine.oppenentMovement.horizontalInput = direction;
    }

    
    public override void ExitState()
    {
        
    }

    
    public AttackState(OpponentStateMachine stateMachine) : base(stateMachine) { }
}
