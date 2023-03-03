using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform groundCheck;
    public PlayerInputHandler InputHandler { get; private set; }
    public Animator Animator { get; private set; }
    public Rigidbody2D rBody { get; private set; }

    [SerializeField]
    List<PlayerStates> states;

    public Dictionary<System.Type, PlayerStates> statesTable = new Dictionary<System.Type, PlayerStates>();
    public PlayerStateMachine StateMachine { get; private set; }

    public int facingDirection;

    [SerializeField]
    PlayerData PlayerData;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        StateMachine = new PlayerStateMachine();
        InputHandler = GetComponent<PlayerInputHandler>();
        
    }
    private void Start()
    {
        foreach (var state in states)
        {
            state.Initialize(this, PlayerData, Animator);
            statesTable.Add(state.GetType(), state);
        }
        StateMachine.InitState(statesTable[typeof(Player_IdleState)]);
        facingDirection = (int)transform.localScale.x;
    }
    private void Update()
    {
        Flip();
        DoChecks();
        StateMachine.CurrentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    public void DoChecks()
    {
        GroundCheck();
    }
    public bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheck.position, PlayerData.groundCheckRadius, PlayerData.whatIsGround);
    }
    public void SetVelocityX(float velocity)
    {
        rBody.velocity = new Vector2(velocity * InputHandler.movementInput.x, rBody.velocity.y);
    }
    public void Flip()
    {
        if (InputHandler.movementInput.x!=0&&InputHandler.movementInput.x != facingDirection)
        {
            transform.Rotate(0.0f, 180.0f, 0.0f);
            facingDirection *= -1;

        }
        

    }
    public void SetVelocityY(float velocity)
    {
        rBody.velocity=new Vector2(rBody.velocity.x, velocity);
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position,0.2f);
    }
}
