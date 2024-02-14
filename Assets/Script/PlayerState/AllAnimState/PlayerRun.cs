using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : PlayerGrounded
{
    public PlayerRun(BasePlayer player, PlayerStateMachine stateMachine, string animname) : base(player, stateMachine, animname)
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
        // pCmoveInputs.updateMovements(xInputs, 25);
     //   pCmoveInputs.updateMOvement(player.transform, 0.0f, xInputs);
        if (xInputs == 0)
        {   
            stateMachine.onChangeState(player.PlayerIdle);
        }
    }
}
