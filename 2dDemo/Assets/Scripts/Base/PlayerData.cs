using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Data/PlayerData",fileName ="newData")]
public class PlayerData :ScriptableObject
{
    public float moveSpeed = 10.0f;

    public LayerMask whatIsGround;
    
    public float groundCheckRadius = 0.2f;

    public float jumpForce = 30.0f;
}
