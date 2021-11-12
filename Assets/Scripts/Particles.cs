using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour {

private bool parTriggered;
public ParticleSystem part;	
		
void OnTriggerEnter(Collider col)
{
   if(col.tag == "Player")
	{
		parTriggered = true;
	}
	
}
void OnTriggerExit(Collider other) 
{
   	parTriggered = false;
    }

// Use this for initialization
void Start () 
{
	
}

// Update is called once per frame
void Update () 
{
	
	if(parTriggered == true)
  {  
    Debug.Log("Particles playing");
    part.Play();
  }

	if(parTriggered == false)
	{
		Debug.Log("Particles not playing");
		part.Stop();		
	}	
}
}