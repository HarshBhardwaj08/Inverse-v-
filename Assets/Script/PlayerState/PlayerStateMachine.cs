using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
  public PlayerState currentstate { get;  set; }
   public void onEnterState(PlayerState state)
    {   
       this.currentstate = state;
        currentstate .Onstart();
    }
    public void onChangeState(PlayerState state)
    {
       this.currentstate .OnExit();
       this.currentstate = state;
        currentstate.Onstart();

    }
}
