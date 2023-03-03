using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MoveState", menuName = "PlayerStates/StateData/Move")]
public class Player_MoveState : PlayerGroundedStates
{
    public override void Enter()
    {
        animator.SetBool("move", true);
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        Player.Animator.SetBool("move", false);
    }

    public override void LogicUpdate()
    {
        Player.SetVelocityX(PlayerData.moveSpeed);
        if (Player.InputHandler.movementInput.x == 0)
        {
            Player.StateMachine.ChangeState(Player.statesTable[typeof(Player_IdleState)]);
        }
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
