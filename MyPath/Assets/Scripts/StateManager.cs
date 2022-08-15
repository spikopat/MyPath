using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private GlobalVariables.GameStates Gamestate;

    private void Start()
    {
        ChangeState(GlobalVariables.GameStates.InGame);
    }

    //Called by FinishTrigger
    public void ChangeState(GlobalVariables.GameStates newState)
    {
        Gamestate = newState;
    }

    public GlobalVariables.GameStates GetState()
    {
        return Gamestate;
    }

    public bool CheckState(GlobalVariables.GameStates state)
    {
        return Gamestate == state;
    }

}