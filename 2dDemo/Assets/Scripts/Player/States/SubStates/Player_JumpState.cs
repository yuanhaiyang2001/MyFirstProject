using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "JumpState", menuName = "PlayerStates/StateData/JumpState")]
public class Player_JumpState : PlayerAbilityStates
{
    public override void Enter()
    {

        animator.SetBool("jump", true);
        Player.SetVelocityY(PlayerData.jumpForce);
        base.Enter();
    }

    public override void Exit()
    {
        animator.SetBool("jump", false);
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (Player.GroundCheck() && Player.rBody.velocity.y == 0f && Player.InputHandler.movementInput.x==0)
        {
            Player.StateMachine.ChangeState(Player.statesTable[typeof(Player_IdleState)]);
        }
        else if(Player.GroundCheck() && Player.rBody.velocity.y == 0f && Player.InputHandler.movementInput.x != 0)
        {
            Player.StateMachine.ChangeState(Player.statesTable[typeof(Player_MoveState)]);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
