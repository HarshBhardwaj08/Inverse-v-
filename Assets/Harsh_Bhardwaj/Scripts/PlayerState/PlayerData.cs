using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
    protected PlayerStateMachine stateMachine;
    public BasePlayer player;
    public float InputX;
    string animboolname;
    protected Rigidbody2D rg2d;
    protected int turnDir;
    protected bool isAttacking;
    protected float stunnedTime;
    protected float DeacivateKamui;
    protected int jumpCount;
    protected int maxJumpCount = 2;
    public PlayerData(BasePlayer player, PlayerStateMachine stateMachine, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animboolname = animBoolName;
    }

    public virtual void playerEnter()
    {
        rg2d = player.rb; 
        player.animator.SetBool(animboolname, true);
    }

    public virtual void playerExit()
    {
        player.animator.SetBool(animboolname, false);

    }

    public virtual void PlayerUpdate()
    {
         InputX = Input.GetAxis("Horizontal");
       
        if (InputX > 0)
        {
            turnDir = 1;
           
        }
        else if(InputX < 0)
        {
            turnDir = -1;
           
        }
       


    }
    public virtual void IsAttacking() => isAttacking = true;
}
