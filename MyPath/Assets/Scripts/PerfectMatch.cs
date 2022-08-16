using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PerfectMatch : MonoBehaviour
{
    [SerializeField] private Transform greatTextSpawnPosition;
    [SerializeField] private Transform greatText;

    private void Start()
    {
        

    }

    //Called by PlatformSplitter.cs
    public void PerfectMatchEvents()
    {
        RoadScript previousRoad = PlatformSpawner.Instance.GetLastSpawnedRoad();
        Color tempColor = previousRoad.GetColor();

        //Spawn feedback text
        Instantiate(greatText, greatTextSpawnPosition.position, Quaternion.identity, greatTextSpawnPosition.parent);

        previousRoad.BlinkColor(Color.white, 0.2f, 3);
    }

}