using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : PlayerGrounded
{
    public PlayerWalk(BasePlayer player, PlayerStateMachine stateMachine, string animname) : base(player, stateMachine, animname)
    {
    }
   
    public override void OnExit()
    {
        base.OnExit();
       
    }

    public override void Onstart()
    {
        base.Onstart();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
     
    }
   
}
