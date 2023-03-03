using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "IdleState", menuName = "PlayerStates/StateData/Idle")]
public class Player_IdleState : PlayerGroundedStates
{
    public override void Enter()
    {
        Player.SetVelocityX(0);
        animator.SetBool("idle", true);
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        Player.Animator.SetBool("idle", false);
    }

    public override void LogicUpdate()
    {
        if (Player.InputHandler.movementInput.x != 0)
        {
            Player.StateMachine.ChangeState(Player.statesTable[typeof(Player_MoveState)]);
        }
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
