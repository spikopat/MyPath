using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChibiAnimatorController : MonoBehaviour
{
    private string Dance = "Dance";
    [SerializeField] private Animator animator;

    private void Start()
    {
        
    }

    public void DanceTrigger()
    {
        animator.SetTrigger(Dance);
    }

}