using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(BasePlayer player, PlayerStateMachine stateMachine, string animname) : base(player, stateMachine, animname)
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
       
        if(player.isGrounded() == true)
        {
            stateMachine.onChangeState(player.PlayerIdle);
        }

    }
}
