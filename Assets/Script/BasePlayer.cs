using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    [SerializeField] Transform foot;
    [SerializeField] LayerMask layerMask;
    public PlayerState State { get; set;}
    public Rigidbody2D m_Rigidbody2 { get; set; }
    public PlayerStateMachine StateMachine { get; set;}
    public Animator m_Animator {  get; set; }   
    public float speed;
    public PlayerIdle PlayerIdle { get; set; }
    public PlayerWalk PlayerWalk { get; set; }
   
    public PlayerGrounded PlayerGrounded { get; set; }
    public PlayerAirState PlayerAirState { get; set; }
    public PlayerJump PlayerJump { get; set; }
    public PlayerDoubleJump PlayerDoubleJump { get; set; }
    public float val = 0;
    public float jumpHeight;
    public float Runvelocity;
    [Range(0f, 360f)]
    public float angle;
    public virtual void Awake()
    {
        m_Rigidbody2 = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        StateMachine = new PlayerStateMachine();
        PlayerIdle = new PlayerIdle(this, StateMachine, "Idle");
        PlayerWalk = new PlayerWalk(this, StateMachine, "Walk");
        PlayerAirState = new PlayerAirState(this, StateMachine, "Jump");
        PlayerJump = new PlayerJump(this, StateMachine, "Jump");
        PlayerDoubleJump = new PlayerDoubleJump(this, StateMachine, "DoubleJump");
      
    }
    public virtual void Start()
    {
        
    }
   public virtual void Update()
    {
      
    }
    public void SetDirection(float dir)
    {
        this.transform.localScale = new Vector3(dir, 1, 1);
    }
    public bool isGrounded()
    {
        return Physics2D.OverlapCircle(foot.position, 0.05f, layerMask);
    }
    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawSphere(foot.transform.position, 0.05f);
        Vector2 dir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        
        Gizmos.DrawLine(foot.position,dir*jumpHeight);
    }
}
