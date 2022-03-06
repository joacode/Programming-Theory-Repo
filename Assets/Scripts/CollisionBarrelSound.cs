using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBarrelSound : MonoBehaviour
{
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        source.Play();
    }
}
