using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSettings : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float roadSpeed;

    public void SetSpawnedRoadSettings(RoadScript spawnedRoad, int spawnCounter)
    {
        if (spawnCounter % 2 == 0)
            spawnedRoad.SetDirectionType(GlobalVariables.DirectionType.Left);
        else
            spawnedRoad.SetDirectionType(GlobalVariables.DirectionType.Right);

        spawnedRoad.SetRoadSpeed(roadSpeed);
    }
}