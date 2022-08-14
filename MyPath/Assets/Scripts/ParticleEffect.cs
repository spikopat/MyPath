using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] ParticleSystems;

    public void PlayParticle()
    {
        foreach (var particle in ParticleSystems)
        {
            particle.gameObject.SetActive(true);
            particle.Play();
        }
    }
}