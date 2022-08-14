using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlatformSplitter : MonoBehaviour
{
    [SerializeField] private Transform roadsParent;
    public UnityEvent<GlobalVariables.GameStates> GameFailEvent;

    public void SplitPlatform(RoadScript lastSpawnedRoad)
    {
        RoadScript previousRoad = GetPreviousRoad(lastSpawnedRoad);

        //Yeni yol ile eski yol arasýndaki farký aldýk.
        float xDifferenceBetweenRoads = lastSpawnedRoad.transform.position.x - previousRoad.transform.position.x;

        if (HasGameFailed(xDifferenceBetweenRoads, lastSpawnedRoad))
        {
            lastSpawnedRoad.AddComponent<Rigidbody>();
            GameFailEvent?.Invoke(GlobalVariables.GameStates.Fail);
            return;
        }

        float direction = GetDirectionMultiplier(xDifferenceBetweenRoads);
        float newXSize = GetNewRoadXScale(lastSpawnedRoad, xDifferenceBetweenRoads);    //Yeni yolun sistemde kalacak miktari belirlendi.
        float newXPosition = GetNewRoadXPosition(previousRoad, xDifferenceBetweenRoads);    //Yeni yolun x pozisyonunu belirledik.
        SetNewRoadSettings(lastSpawnedRoad, newXSize, newXPosition);

        float fallingBlockSize = lastSpawnedRoad.transform.localScale.x - newXSize; //Dusecek blogun boyutu.
        float cubeEdge = lastSpawnedRoad.transform.position.x + (newXSize / 2f * direction);
        float fallingBlockXPosition = cubeEdge + fallingBlockSize / 2f * direction;
        SpawnDropCube(fallingBlockXPosition, fallingBlockSize, lastSpawnedRoad);
    }

    private void SpawnDropCube(float fallingBlockXPosition, float fallingBlockSize, RoadScript lastSpawnedRoad)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(fallingBlockSize, lastSpawnedRoad.transform.localScale.y, lastSpawnedRoad.transform.localScale.z);
        cube.transform.position = new Vector3(fallingBlockXPosition, lastSpawnedRoad.transform.position.y, lastSpawnedRoad.transform.position.z);
        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Renderer>().material = lastSpawnedRoad.GetComponent<Renderer>().material;

        Destroy(cube.gameObject, 1f);
    }

    #region Calculations
    private RoadScript GetPreviousRoad(RoadScript lastSpawnedRoad)
    {
        return roadsParent.GetChild(lastSpawnedRoad.transform.GetSiblingIndex() - 1).GetComponent<RoadScript>();
    }

    private float GetNewRoadXPosition(RoadScript previousRoad, float xDifferenceBetweenRoads)
    {
        return previousRoad.transform.position.x + (xDifferenceBetweenRoads / 2);
    }

    private float GetNewRoadXScale(RoadScript lastSpawnedRoad, float xDifferenceBetweenRoads)
    {
        return lastSpawnedRoad.transform.localScale.x - Mathf.Abs(xDifferenceBetweenRoads);
    }

    private float GetDirectionMultiplier(float xDifferenceBetweenRoads)
    {
        return xDifferenceBetweenRoads > 0 ? 1f : -1f;
    }
    
    private void SetNewRoadSettings(RoadScript lastSpawnedRoad, float newXSize, float newXPosition)
    {
        lastSpawnedRoad.transform.localScale = new Vector3(newXSize, lastSpawnedRoad.transform.localScale.y, lastSpawnedRoad.transform.localScale.z);
        lastSpawnedRoad.transform.position = new Vector3(newXPosition, lastSpawnedRoad.transform.position.y, lastSpawnedRoad.transform.position.z);
    }
    #endregion

    private bool HasGameFailed(float xDifferenceBetweenRoads, RoadScript lastSpawnedRoad)
    {
        return Mathf.Abs(xDifferenceBetweenRoads) >= lastSpawnedRoad.transform.localScale.x;
    }

}