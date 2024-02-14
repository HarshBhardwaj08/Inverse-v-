using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{  
    public PlayerState State { get; set;}
    public Rigidbody2D m_Rigidbody2 { get; set; }
    public PlayerStateMachine StateMachine { get; set;}
    public Animator m_Animator {  get; set; }   
    public float speed;
    public PlayerIdle PlayerIdle { get; set; }
    public PlayerWalk PlayerWalk { get; set; }
    public PlayerRun PlayerRun { get; set; }
    public PlayerGrounded PlayerGrounded { get; set; }
    public PlayerAirState PlayerAirState { get; set; }
    public PlayerDoubleJump PlayerDoubleJump { get; set; }
    public float val = 0;
    public virtual void Awake()
    {
      
        m_Rigidbody2 = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        StateMachine = new PlayerStateMachine();
        PlayerIdle = new PlayerIdle(this, StateMachine, "Idle");
        PlayerWalk = new PlayerWalk(this, StateMachine, "Walk");
        PlayerRun = new PlayerRun(this, StateMachine, "Run");
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
}
