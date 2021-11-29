using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLevel : MonoBehaviour
{
private bool partsTriggered;	
public GameObject trophyPartObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SilverTrophy")
        {
            SceneManager.LoadScene(1);
            partsTriggered = true;
        }       
        else if (other.tag == "BronzeTrophy")
        {
            SceneManager.LoadScene(2);
            partsTriggered = true;
        }
    }


    IEnumerator TrophyParticleTimer()
{
    trophyPartObject.gameObject.SetActive(true);
    yield return new WaitForSeconds(2);
    trophyPartObject.gameObject.SetActive(false);
    partsTriggered = false;
}

private void Start () 
{
	trophyPartObject.gameObject.SetActive(false);
}

// Update is called once per frame
void Update () 
{
	if(partsTriggered == true)
  {
    StartCoroutine("TrophyParticleTimer");
  }

  if(partsTriggered == false)
  {
    StopCoroutine("TrophyParticleTimer");
  }
	
}		
}
