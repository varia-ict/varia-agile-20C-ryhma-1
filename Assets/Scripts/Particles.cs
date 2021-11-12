using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour {

private bool parTriggered;	
public GameObject partObject;
		
void OnTriggerEnter(Collider col)
{
   if(col.gameObject.tag == "Mushroom")
	{
		parTriggered = true;
	}
	
}

private void Start () 
{
	partObject.gameObject.SetActive(false);
}

// Update is called once per frame
void Update () 
{
	
	if(parTriggered == true)
  {
    Debug.Log("Particles playing");
    partObject.gameObject.SetActive(true);
  }


	if(parTriggered == false)
	{
		Debug.Log("Particles not playing");
		partObject.gameObject.SetActive(false);		
	}	
}		
}