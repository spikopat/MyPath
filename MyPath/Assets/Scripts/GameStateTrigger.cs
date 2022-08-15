using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class GameStateTrigger : MonoBehaviour
{
    [SerializeField] private GlobalVariables.GameStates NextGameState;
    public UnityEvent<GlobalVariables.GameStates> StageCompleteEvent;
    public UnityEvent<GlobalVariables.GameStates> StageFailEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (!StateManager.Instance.CheckState(GlobalVariables.GameStates.InGame))
            return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            DOVirtual.DelayedCall(0.5f, () => {
                StageCompleteEvent?.Invoke(GlobalVariables.GameStates.Complete);
            });
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (StateManager.Instance.GetState() != GlobalVariables.GameStates.InGame)
            return;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StageFailEvent?.Invoke(GlobalVariables.GameStates.Fail);
        }
    }

}