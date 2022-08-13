using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class GameStateTrigger : MonoBehaviour
{
    [SerializeField] private StateManager.GameStates NextGameState;
    public UnityEvent<StateManager.GameStates> StageCompleteEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (!StateManager.Instance.Gamestate.Equals(StateManager.GameStates.InGame))
            return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            DOVirtual.DelayedCall(0.25f, () => {
                StageCompleteEvent?.Invoke(StateManager.GameStates.Complete);
            });
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!StateManager.Instance.Gamestate.Equals(StateManager.GameStates.InGame))
            return;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StageCompleteEvent?.Invoke(StateManager.GameStates.Fail);
        }
    }

}