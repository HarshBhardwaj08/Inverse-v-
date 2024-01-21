using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerStateMachine 
{
    public PlayerData currentstate { get; set; }

    public void Intialize(PlayerData _startState)
    {
        currentstate = _startState;
        currentstate.playerEnter();
    }
    public void ChangeState(PlayerData _newstate)
    {
        currentstate.playerExit();
        currentstate = _newstate;
        currentstate.playerEnter();
    }
}
