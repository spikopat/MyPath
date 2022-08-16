using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedbackText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        DOTween.Sequence()
            .Append(text.DOFade(0.1f, 1f))
            .Join(transform.DOLocalMoveY(transform.localPosition.y + 200f, 1f))
            .OnComplete(() => {
                Destroy(gameObject);
            });
    }
}