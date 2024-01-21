using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    public Animator animator { get; set; }
    public Rigidbody2D rb { get; set; }
    public PlayerStateMachine stateMachine { get; set; }
    public PlayerIdleState idleState { get; set; }
    public PlayerMoveState moveState { get; set; }
    public PlayerJumpState jumpState { get; set; }
    public LayerMask ground;
    public float distance;
    public float speed;
    public bool isGrd;
    public float insitalspeed { get; set; }
    public virtual void Awake()
    {
        insitalspeed = speed;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    public virtual void Start()
    {

    }


    public virtual void Update()
    {
       
    }

    public virtual void SetVelocity(float x, float y)
    {
        rb.velocity = new Vector2(x * speed, y);
    }
    public virtual void SetDir(float speed)
    {
        transform.localScale = new Vector3(speed, transform.localScale.y, transform.localScale.z);
    }

    public virtual bool  isGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distance, ground);
    }
   public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, Vector3.down *distance) ;
    }
}
