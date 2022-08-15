using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class ChibiController : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float moveSpeed;
    [SerializeField, Range(0, 10)] private float horizontalMoveSpeed;

    private void Start()
    {
        DOVirtual.DelayedCall(8.5f, () => { 
            IncreaseSpeed();
        });
    }

    private void Update()
    {
        if (StateManager.Instance.CheckState(GlobalVariables.GameStates.InGame))
        {
            Run();
        }
    }

    private void IncreaseSpeed()
    {
        moveSpeed += 0.15f;

        DOVirtual.DelayedCall(8.5f, () => {
            IncreaseSpeed();
        });
    }

    private void Run()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        transform.position = Vector3.Lerp(transform.position, new Vector3(CalculateNewXPosition(), transform.position.y, transform.position.z), Time.deltaTime * horizontalMoveSpeed);
    }

    private float CalculateNewXPosition()
    {
        float newXPos;
        if (PlatformSpawner.Instance.GetPreviousRoad().HasStopped())
            newXPos = PlatformSpawner.Instance.GetPreviousRoad().transform.position.x;
        else
            newXPos = 0;

        return newXPos;
    }

}