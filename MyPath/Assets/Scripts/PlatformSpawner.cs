using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public List<GameObject> roadPrefabs = new List<GameObject>();
    [SerializeField] private Transform roadsParent;

    private int spawnedRoadCounter;
    public GameObject lastSpawnedRoad;

    private void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            SpawnRoad();
        }
    }

    private void SpawnRoad()
    {
        Vector3 spawnPosition = new Vector3(
            lastSpawnedRoad.transform.position.x, 
            lastSpawnedRoad.transform.position.y, 
            lastSpawnedRoad.transform.position.z + lastSpawnedRoad.transform.GetChild(0).localScale.z
            );

        GameObject spawnedRoad = Instantiate(roadPrefabs[spawnedRoadCounter % roadPrefabs.Count], spawnPosition, Quaternion.identity, roadsParent);
        spawnedRoadCounter++;
        lastSpawnedRoad = spawnedRoad;
    }

}