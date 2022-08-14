using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCamera : MonoBehaviour
{
    [SerializeField, Range(0f, 20f)] private float turnSpeed;

    float newYAngle;

    private void Update()
    {
        TurnAround();
    }

    private void TurnAround()
    {
        newYAngle = Mathf.Repeat(transform.localEulerAngles.y - Time.deltaTime * turnSpeed, 360f);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, newYAngle, transform.localEulerAngles.z);
    }

}