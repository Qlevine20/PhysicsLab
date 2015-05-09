using UnityEngine;
using System.Collections;

public class TargetPart : MonoBehaviour
{

    public ParticleSystem Explosion;

    void Awake()
    {
        Explosion.enableEmission = false;
    }
}