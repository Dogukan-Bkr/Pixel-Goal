using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentStateMachine : MonoBehaviour
{
    private OpponentState currentState;
    public CharacterMovement oppenentMovement;
    public Transform playerTransform;
    public Transform ballTransform;
    public Transform defencePoint;
    void Start()
    {
        currentState = new IdleState(this);
        currentState.EnterState();
    }
    void Update()
    {
        CheckStateChange();
        currentState.UpdateState();
    }

    private void CheckStateChange()
    {
        float playerDistanceToBall = Mathf.Abs(ballTransform.position.x - playerTransform.position.x);
        if (playerDistanceToBall < 5)
        {
            ChangeState(new DefenceState(this));
        }
        else
        {
            ChangeState(new AttackState(this));
        }
    }

    public void ChangeState(OpponentState state)
    {
        currentState.ExitState();
        currentState = state;
        currentState.EnterState();
    }
}