using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerState
{
    public BasePlayer player;
    Animator animator;
    public PlayerStateMachine stateMachine;
    public string animBoolName;
    public Rigidbody2D rb;
   protected PCmoveInputs pCmoveInputs {  get; set; } 
   protected  float speed {  get; private set; }
  protected float xInputs {  get; set; }
   protected float dir {  get; private set; }
    private float gravityStrength = 9.8f;
    public PlayerState (BasePlayer player, PlayerStateMachine stateMachine,string animname)
    {
        this.player = player;
        this.animBoolName = animname; 
        this.stateMachine = stateMachine;
        animator = player.m_Animator;
        rb = player.m_Rigidbody2;
        speed = player.speed;
        pCmoveInputs = new PCmoveInputs (rb,speed,xInputs);
       
    }

    public virtual void Onstart() 
    {
       animator.SetBool(animBoolName, true);
      
    }   
    public virtual void OnExit() 
    {
        animator.SetBool(animBoolName, false);
      
    }

    public virtual void OnUpdate()
    {
        xInputs = Input.GetAxis("Horizontal");
        // player.SetVelocity(xInputs);
      
        if (xInputs > 0)
        {
            dir = 1;
        }
        else if (xInputs < 0)
        {
          dir= -1;
        }
        if(rb.velocity.y > 0)
        {

       player.transform.position += Vector3.down * gravityStrength * Time.deltaTime;
        }
    }
   
}
