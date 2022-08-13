using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class ChibiController : MonoBehaviour
{
    [Range(0, 10)]public float MoveSpeed;

    private void Start()
    {

    }

    private void Update()
    {
        if(StateManager.Instance.Gamestate.Equals(StateManager.GameStates.InGame))
            Run();
    }

    private void Run()
    {
        transform.Translate(transform.forward * Time.deltaTime * MoveSpeed);
    }

}