using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem bloodParticleSystem;
    void Start()
    {
        bloodParticleSystem = GetComponent<ParticleSystem>();
        bloodParticleSystem.Play();
        Destroy(gameObject, bloodParticleSystem.main.duration);
    }
}
