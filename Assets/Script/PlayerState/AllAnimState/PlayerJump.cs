using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerState
{
    public PlayerJump(BasePlayer player, PlayerStateMachine stateMachine, string animname) : base(player, stateMachine, animname)
    {
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void Onstart()
    {
        base.Onstart();
       velocity = Mathf.Sqrt(player.jumpHeight
           * (rb.gravityScale * Physics2D.gravity.y) * -2) * rb.mass;
        Vector2 dir = new Vector2(Mathf.Cos(Mathf.Deg2Rad * player.angle), Mathf.Sin(Mathf.Deg2Rad * player.angle));
        Debug.Log(Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg);
        player.m_Rigidbody2.velocity += dir*5*player.jumpHeight;
       // rb.AddForce(dir * player.jumpHeight*5, ForceMode2D.Impulse);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (player.m_Rigidbody2.velocity.y < 0)
        {
            stateMachine.onChangeState(player.PlayerAirState);
        }
        if (Input.GetKeyDown(KeyCode.Space) && player.isGrounded() == false)
        {
            stateMachine.onChangeState(player.PlayerDoubleJump);
        }
    }
}
