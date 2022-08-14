using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public enum DirectionType : byte
    {
        None,
        Left,
        Right
    }

    public enum GameStates : byte
    {
        InGame,
        Complete,
        Fail
    }

}