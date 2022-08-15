using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonScript : MonoBehaviour
{
    private void Start()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(1.05f, 1f))
            .Append(transform.DOScale(0.95f, 1f))
            .SetLoops(-1);
    }

    private void OnDisable()
    {
        DOTween.Kill(transform);
    }

}