using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour {

private bool parTriggered;	
public GameObject partObject;
		

IEnumerator ParticleTimer()
{
    partObject.gameObject.SetActive(true);

    yield return new WaitForSeconds(3);

    partObject.gameObject.SetActive(false);
	parTriggered = false;
}

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
    StartCoroutine("ParticleTimer");
  }

  if(parTriggered == false)
  {
    StopCoroutine("ParticleTimer");
  }
	
}		
}