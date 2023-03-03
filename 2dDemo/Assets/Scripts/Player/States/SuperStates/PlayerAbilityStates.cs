using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityStates : PlayerStates
{
    protected bool isAbilityDone;
    public bool isGrounded;
    public override void Enter()
    {
        isAbilityDone = false;
        isGrounded = Player.GroundCheck();
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAbilityDone)
        {
            if(isGrounded && Player.rBody.velocity.y < 0.01)
            {
                Player.StateMachine.ChangeState(Player.statesTable[typeof(Player_IdleState)]);
            }
            else
            {
                Player.StateMachine.ChangeState(Player.statesTable[typeof(Player_InAirState)]);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
