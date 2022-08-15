using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner Instance;

    public PlatformSettings PlatformSettings;
    public PlatformSplitter PlatformSplitter;

    [Space(10)]
    public List<GameObject> roadPrefabs = new List<GameObject>();

    [Space(10)]
    public Transform LeftPoint;
    public Transform RightPoint;

    [SerializeField] private Transform roadsParent;
    [SerializeField] private RoadScript lastSpawnedRoad;

    [Space(10)]
    [SerializeField, Range(0, 5f)] private float waitForSpawnNewRoad;

    private int spawnedRoadCounter;

    #region UnityFunctions
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        RoadScript spawnedRoad = SpawnRoad();

        spawnedRoadCounter++;
        lastSpawnedRoad = spawnedRoad;
        PlatformSettings.SetSpawnedRoadSettings(lastSpawnedRoad, spawnedRoadCounter);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastSpawnedRoad.StopRoad();
            PlatformSplitter.SplitPlatform(lastSpawnedRoad);

            RoadScript spawnedRoad = SpawnRoad();
            lastSpawnedRoad = spawnedRoad;
            spawnedRoadCounter++;
            PlatformSettings.SetSpawnedRoadSettings(lastSpawnedRoad, spawnedRoadCounter);
        }
    }
    #endregion

    private RoadScript SpawnRoad()
    {
        Vector3 spawnPosition = new Vector3(
            GetSpawnPositionXAxis(), 
            lastSpawnedRoad.transform.position.y, 
            lastSpawnedRoad.transform.position.z + (lastSpawnedRoad.transform.localScale.z)
            );

        Vector3 spawnScale = new Vector3(lastSpawnedRoad.transform.localScale.x, lastSpawnedRoad.transform.localScale.y, lastSpawnedRoad.transform.localScale.z);
        
        GameObject spawablePrefab = roadPrefabs[spawnedRoadCounter % roadPrefabs.Count];
        GameObject spawnedRoad = Instantiate(spawablePrefab, spawnPosition, Quaternion.identity, roadsParent);
        
        spawnedRoad.transform.localScale = spawnScale;
        return spawnedRoad.GetComponent<RoadScript>();
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

    public RoadScript GetLastSpawnedRoad()
    {
        return lastSpawnedRoad;
    }

    public RoadScript GetPreviousRoad()
    {
        return roadsParent.GetChild(lastSpawnedRoad.transform.GetSiblingIndex() - 1).GetComponent<RoadScript>();
    }
}