using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "InAirState", menuName = "PlayerStates/StateData/InAirState")]
public class Player_InAirState : PlayerStates
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("inair");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
