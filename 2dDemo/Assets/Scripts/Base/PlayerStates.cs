using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStates:ScriptableObject
{
    protected Animator animator;
    protected float StartTime { get; private set; }
    protected PlayerData PlayerData { get; private set; }
    protected Player Player { get; private set; }
    public void Initialize(Player player,PlayerData stateData,Animator animator)
    {
        Player = player;
        PlayerData = stateData;
        this.animator = animator;
    }
    public virtual void Enter()
    {
        StartTime = Time.time;
       
    }
    public virtual void Exit()
    {
      
    }
    public virtual void LogicUpdate()
    {

    }
    public virtual void PhysicsUpdate()
    {

    }
    
}
