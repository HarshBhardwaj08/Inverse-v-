using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dave : BasePlayer
{
    public override void Awake()
    {  
        base.Awake();
    }
    public override void Start()
    {
        base .Start();
        StateMachine.onEnterState(PlayerIdle);
    }

    // Update is called once per frame
    public override void Update()
    { 
        base.Update();
        StateMachine.currentstate.OnUpdate();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() == true)
        {
            float velocity = Mathf.Sqrt(jumpHeight
            * (m_Rigidbody2.gravityScale * Physics2D.gravity.y) * -2) * m_Rigidbody2.mass;
            m_Rigidbody2.velocity = new Vector2 (0, velocity);
        }
    }
   
}
