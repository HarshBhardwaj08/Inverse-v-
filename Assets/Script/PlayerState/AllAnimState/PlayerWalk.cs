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
        player.SetDirection(dir);
        if (xInputs == 0)
        {
            stateMachine.onChangeState(player.PlayerIdle);
        }
        if (chnagestate > 3.0f)
        {
            stateMachine.onChangeState(player.PlayerRun);
        }
    }
   
}
