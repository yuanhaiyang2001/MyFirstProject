using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerStates CurrentState { get; private set; }
    public void InitState(PlayerStates startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }
    public void ChangeState(PlayerStates newState)
    {
        CurrentState.Exit();
        InitState(newState);
    }
}
