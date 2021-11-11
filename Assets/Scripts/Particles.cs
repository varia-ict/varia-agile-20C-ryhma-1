using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour {

   ParticleSystem partEffect;

    void Start () 
    {
       partEffect = GetComponent<ParticleSystem>();
    }
    void Update () 
    {

    }
    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Mushroom")
        {
            partEffect.Play();
        }
}
}