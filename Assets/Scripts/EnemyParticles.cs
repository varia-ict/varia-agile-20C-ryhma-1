using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticles : MonoBehaviour {

private bool parTriggered;	
public GameObject enemyPartObject;
		

IEnumerator EnemyParticleTimer()
{
  enemyPartObject.gameObject.SetActive(true);
  yield return new WaitForSeconds(2);
  enemyPartObject.gameObject.SetActive(false);
	parTriggered = false;
}

void OnTriggerEnter(Collider col)
{
   if(col.gameObject.tag == "Enemy")
	{
		parTriggered = true;
	}
}

private void Start () 
{
	enemyPartObject.gameObject.SetActive(false);
}

// Update is called once per frame
void FixedUpdate () 
{
	if(parTriggered == true)
  {
    StartCoroutine("EnemyParticleTimer");
  }

  if(parTriggered == false)
  {
    StopCoroutine("EnemyParticleTimer");
  }
	
}		
}
