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
        switch (Gamestate)
        {
            case GlobalVariables.GameStates.InGame:
                break;
            case GlobalVariables.GameStates.Complete:
                break;
            case GlobalVariables.GameStates.Fail:
                FailState();
                break;
            default:
                break;
        }
    }

    public GlobalVariables.GameStates GetState()
    {
        return Gamestate;
    }

    public bool CheckState(GlobalVariables.GameStates state)
    {
        return Gamestate == state;
    }

    private void FailState()
    {
        GameObject[] roads = GameObject.FindGameObjectsWithTag("Road");
        foreach (GameObject item in roads)
        {
            item.gameObject.SetActive(false);
        }
    }

}