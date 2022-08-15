using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PerfectMatch : MonoBehaviour
{

    private void Start()
    {
        

    }

    //Called by PlatformSplitter.cs
    public void PerfectMatchEvents()
    {
        RoadScript previousRoad = PlatformSpawner.Instance.GetLastSpawnedRoad();
        Color tempColor = previousRoad.GetColor();

        previousRoad.BlinkColor(Color.white, 0.2f, 3);
    }

}