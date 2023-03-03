using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedStates : PlayerStates
{
    protected bool isGrounded;
    
    public override void Enter()
    {
        base.Enter();
        isGrounded = Player.GroundCheck();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Player.InputHandler.JumpInput)
        {
            Player.InputHandler.JumpInputUsed();
            Player.StateMachine.ChangeState(Player.statesTable[typeof(Player_JumpState)]);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
