using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerData
{
    public PlayerJumpState(BasePlayer player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void playerEnter()
    {
        base.playerEnter();
        player.SetVelocity(0, 5.0f);
    }

    public override void playerExit()
    {
        base.playerExit();

    }

    public override void PlayerUpdate()
    {
        base.PlayerUpdate();
        if (rg2d.velocity.y <= 0)
        {
            
            stateMachine.ChangeState(player.idleState);
        }
    }
}
