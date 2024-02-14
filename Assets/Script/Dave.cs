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
    }
   
}
