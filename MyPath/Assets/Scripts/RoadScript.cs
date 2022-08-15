using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoadScript : MonoBehaviour
{
    [SerializeField] private Renderer MRenderer;

    private float roadSpeed;
    [HideInInspector] public GlobalVariables.DirectionType direction;

    private bool hasStopped;
    private Color initialColor;

    private void Start()
    {

        initialColor = MRenderer.material.color;
    }

    private void Update()
    {
        if (!StateManager.Instance.CheckState(GlobalVariables.GameStates.InGame) || hasStopped)
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

    public bool HasStopped()
    {
        return hasStopped;
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

    public Color GetColor()
    {
        return MRenderer.material.color;
    }

    public void BlinkColor(Color newColor, float time, int loopCount)
    {
        DOTween.Sequence()
            .Append(MRenderer.material.DOColor(newColor, time))
            .Append(MRenderer.material.DOColor(initialColor, time / 2))
            .SetLoops(loopCount);
    }

}