using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AnimationCurve calculatedPitch;

    //Called by PlayformSplitter.cs
    public void PlaySuccessSound(int perfectMatchCount)
    {
        AudioSource.pitch = calculatedPitch.Evaluate(perfectMatchCount);
        AudioSource.Play();
    }

}