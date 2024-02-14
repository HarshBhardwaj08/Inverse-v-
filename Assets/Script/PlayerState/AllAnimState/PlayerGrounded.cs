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
        updateMovement(player.transform, xInputs);

    }
    public void updateMovement(Transform transform, float xMovement)
    {
       
        if (xMovement != 0)
        {
            if (currentSpeed > player.speed)
            {
                currentSpeed = player.speed;
            }else
            {
                currentSpeed += Time.deltaTime;
            }
        }
        else
        {
            currentSpeed = 0f;
        }
        player.val = currentSpeed;
        float direction = Mathf.Sign(xMovement);
        if (Mathf.Sign(transform.localScale.x) != direction)
        {
            currentSpeed = 0f;
        }
        transform.Translate(new Vector3(currentSpeed*direction * Time.deltaTime, 0, 0));
    }
}
