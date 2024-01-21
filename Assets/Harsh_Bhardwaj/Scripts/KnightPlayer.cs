using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightPlayer : BasePlayer
{
  
    public override void Awake()
    {  
        base.Awake();
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Walk");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
    }
    public override void Start()
    {
        base.Start();
        stateMachine.Intialize(idleState);
    }
    public override void Update()
    {
        base.Update();
        stateMachine.currentstate.PlayerUpdate();
        isGrd = isGrounded();
    }

    public override void SetVelocity(float x, float y)
    {
        base.SetVelocity(x, y);
    }
    public override void SetDir(float speed)
    {
        base.SetDir(speed);
    }
    public override bool isGrounded()
    {
        return base.isGrounded();
    }
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}
