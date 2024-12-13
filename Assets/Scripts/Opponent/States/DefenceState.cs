using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceState : OpponentState
{
    
    public override void EnterState()
    {

    }


    public override void UpdateState()
    {
        
        stateMachine.oppenentMovement.horizontalInput = 0; 

   
        float distanceToDefencePoint = Vector3.Distance(stateMachine.transform.position, stateMachine.defencePoint.position);

      
        if (distanceToDefencePoint < 0.5f) return;

       
        float direction = Mathf.Sign(stateMachine.defencePoint.position.x - stateMachine.transform.position.x);

       
        stateMachine.oppenentMovement.horizontalInput = direction;
    }


    public override void ExitState()
    {
        
    }

    
    public DefenceState(OpponentStateMachine stateMachine) : base(stateMachine) { }
}
