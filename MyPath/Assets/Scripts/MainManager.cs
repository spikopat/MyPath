using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public enum GameStates : byte
    {
        MainMenu,
        InGame,
        Complete,
        Fail
    }

    public GameStates Gamestate;

    private void Start()
    {

        Application.targetFrameRate = 60;
        Gamestate = GameStates.MainMenu;
    }

}