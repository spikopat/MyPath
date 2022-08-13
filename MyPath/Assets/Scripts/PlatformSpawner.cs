using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public List<GameObject> roads = new List<GameObject>();
    private int spawnedRoadCounter;

    private void Start()
    {
        

    }

    private void SpawnRoad()
    {
        GameObject spawnedRoad = Instantiate(roads[spawnedRoadCounter]);
        spawnedRoadCounter++;
    }

}