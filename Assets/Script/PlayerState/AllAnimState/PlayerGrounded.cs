using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounded : PlayerState
{
    public PlayerGrounded(BasePlayer player, PlayerStateMachine stateMachine, string animname) : base(player, stateMachine, animname)
    {
    }
    float currentSpeed;
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
       pCmoveInputs.updateMovement(player.transform,xInputs,out player.val);
        if (xInputs != 0)
        {
            stateMachine.onChangeState(player.PlayerWalk);
        }
      
    }
    
}
