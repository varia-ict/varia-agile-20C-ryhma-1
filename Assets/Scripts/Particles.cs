using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        if(other.tag == "Pickup")
=======
        if(other.tag == "Mushroom")
>>>>>>> Stashed changes
        {
            partEffect.Play();
        }
}
<<<<<<< Updated upstream
=======
public class Particles : MonoBehaviour
{
    public ParticleSystem part;
    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Mushroom")
        {
            part.Play();
        }
        else
        {
            part.Stop();
        }
        
    }
>>>>>>> Stashed changes
}
=======
}
>>>>>>> Stashed changes
