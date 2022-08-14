using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private Transform gameCamera;
    [SerializeField] private Transform finishCamera;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ActivateGameCamera();
    }

    public void ActivateGameCamera()
    {
        finishCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
    }

    //Called by FinishTrigger
    public void ActivateFinishCamera()
    {
        gameCamera.gameObject.SetActive(false);
        finishCamera.gameObject.SetActive(true);
    }

}