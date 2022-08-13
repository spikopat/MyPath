using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class FinishTrigger : MonoBehaviour
{
    public UnityEvent<StateManager.GameStates> StageCompleteEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            DOVirtual.DelayedCall(0.25f, () => { 
                StageCompleteEvent?.Invoke(StateManager.GameStates.Complete);
            });
        }
    }

}