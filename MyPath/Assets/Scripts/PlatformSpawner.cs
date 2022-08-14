using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public List<GameObject> roadPrefabs = new List<GameObject>();

    [Space(10)]
    public Transform LeftPoint;
    public Transform RightPoint;

    [SerializeField] private Transform roadsParent;
    [SerializeField] private RoadScript lastSpawnedRoad;

    [Space(10)]
    [SerializeField, Range(0, 10)] private float roadSpeed;
    [SerializeField, Range(0, 5f)] private float waitForSpawnNewRoad;

    private int spawnedRoadCounter;
    private float timer;

    private void Start()
    {
        SpawnRoadSequence();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastSpawnedRoad.StopRoad();
            SpawnRoadSequence();
            timer = 0;
            return;
        }
    }

    private void SpawnRoadSequence()
    {
        RoadScript spawnedRoad = SpawnRoad();
        lastSpawnedRoad = spawnedRoad;

        spawnedRoadCounter++;

        SetSpawnedRoadSettings(lastSpawnedRoad);
    }

    private RoadScript SpawnRoad()
    {
        Vector3 spawnPosition = new Vector3(
            GetSpawnPositionXAxis(), 
            lastSpawnedRoad.transform.position.y, 
            lastSpawnedRoad.transform.position.z + lastSpawnedRoad.transform.GetChild(0).localScale.z
            );

        GameObject spawablePrefab = roadPrefabs[spawnedRoadCounter % roadPrefabs.Count];

        return Instantiate(spawablePrefab, spawnPosition, Quaternion.identity, roadsParent).GetComponent<RoadScript>();
    }

    private float GetSpawnPositionXAxis()
    {
        float spawnPositionX = 0;

        if (spawnedRoadCounter % 2 == 0)
            spawnPositionX = RightPoint.position.x;
        else
            spawnPositionX = LeftPoint.position.x;

        return spawnPositionX;
    }

    private void SetSpawnedRoadSettings(RoadScript spawnedRoad)
    {
        if (spawnedRoadCounter % 2 == 0)
            spawnedRoad.SetDirectionType(GlobalVariables.DirectionType.Left);
        else
            spawnedRoad.SetDirectionType(GlobalVariables.DirectionType.Right);

        spawnedRoad.SetRoadSpeed(roadSpeed);
    }

}