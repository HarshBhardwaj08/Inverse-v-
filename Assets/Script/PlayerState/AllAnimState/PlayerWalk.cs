using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : PlayerGrounded
{
    public PlayerWalk(BasePlayer player, PlayerStateMachine stateMachine, string animname) : base(player, stateMachine, animname)
    {
    }
    private float chnagestate;
    public override void OnExit()
    {
        base.OnExit();
        chnagestate = 0f;
    }

    public override void Onstart()
    {
        base.Onstart();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        chnagestate += Time.deltaTime;
        //     pCmoveInputs.updateMovements(xInputs, 10);
      //  pCmoveInputs.updateMOvement(player.transform,player.val,xInputs);
    
        player.SetDirection(dir);
        if (chnagestate > 4.0f)
        {
            stateMachine.onChangeState(player.PlayerRun);
        }
        if (xInputs == 0)
        {
            stateMachine.onChangeState(player.PlayerIdle);
        }
    }
   
}
