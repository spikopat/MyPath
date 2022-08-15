using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AnimationCurve calculatedPitch;

    private void Awake()
    {
        Instance = this;
    }

    //Called by PlayformSplitter.cs
    public void PlaySuccessSound(int perfectMatchCount)
    {
        AudioSource.pitch = calculatedPitch.Evaluate(perfectMatchCount);
        AudioSource.Play();
    }

}