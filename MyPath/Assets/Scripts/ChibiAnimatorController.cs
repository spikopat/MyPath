using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChibiAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private string Dance = "Dance";
    private string Fail = "Fail";

    private void Start()
    {
        
    }

    //Called by GameStateTrigger.cs
    public void DanceTrigger()
    {
        animator.SetTrigger(Dance);
    }

    //Called by GameStateTrigger.cs
    public void FailTrigger()
    {
        animator.SetTrigger(Fail);
    }

}