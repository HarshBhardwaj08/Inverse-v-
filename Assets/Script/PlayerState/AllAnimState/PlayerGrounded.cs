using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounded : PlayerState
{
    public PlayerGrounded(BasePlayer player, PlayerStateMachine stateMachine, string animname) : base(player, stateMachine, animname)
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
        pCmoveInputs.updateMovement(player.transform,xInputs,out player.val);
        player.SetDirection(dir);
        if (xInputs != 0)
        {
            stateMachine.onChangeState(player.PlayerWalk);
        }
        if (xInputs == 0)
        {
            stateMachine.onChangeState(player.PlayerIdle);
            player.m_Animator.SetBool("Run", false);
        }
        if (player.val > 3.0f)
        {
            player.m_Animator.SetBool("Run", true);
        }
    /*    if(Input.GetKeyDown(KeyCode.Space) && player.isGrounded()==true)
        {
           stateMachine.onChangeState(player.PlayerJump);
        }*/
       
    }
    
}
