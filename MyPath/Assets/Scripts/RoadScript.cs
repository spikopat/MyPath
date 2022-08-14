using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    private float roadSpeed;
    [HideInInspector] public GlobalVariables.DirectionType direction;

    private bool hasStopped;

    private void Update()
    {
        if (hasStopped)
            return;

        switch (direction)
        {
            case GlobalVariables.DirectionType.Left:
                MoveRight();
                break;
            case GlobalVariables.DirectionType.Right:
                MoveLeft();
                break;
            default:
                break;
        }
    }

    public void StopRoad()
    {
        hasStopped = true;
    }

    public void SetRoadSpeed(float roadSpeed)
    {
        this.roadSpeed = roadSpeed;
    }

    public void SetDirectionType(GlobalVariables.DirectionType directionType)
    {
        direction = directionType;
    }

    private void MoveLeft()
    {
        transform.Translate(Vector3.left * Time.deltaTime * roadSpeed);
    }

    private void MoveRight()
    {
        transform.Translate(Vector3.right * Time.deltaTime * roadSpeed);
    }
}