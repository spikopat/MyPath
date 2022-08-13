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

    public enum GameStates : byte
    {
        InGame,
        Complete,
        Fail
    }

    public GameStates Gamestate;

    private void Start()
    {
        ChangeState(GameStates.InGame);
    }

    //Called by FinishTrigger
    public void ChangeState(GameStates newState)
    {
        Gamestate = newState;
    }

}