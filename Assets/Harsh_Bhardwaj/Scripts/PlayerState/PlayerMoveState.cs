using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(BasePlayer player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void playerEnter()
    {
        base.playerEnter();
    }

    public override void playerExit()
    {
        base.playerExit();
    }

    public override void PlayerUpdate()
    {
        base.PlayerUpdate();
        player.SetDir(turnDir);
        player.SetVelocity(InputX, rg2d.velocity.y);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            player.animator.SetBool("Run", true);
            player.speed = player.insitalspeed * 1.5f;
        }
        if (InputX == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
