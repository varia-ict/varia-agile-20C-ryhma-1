using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyprefab;
    private GameObject enemyContainer;
    private bool StopSpawing = false;
    private float randomX;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SPAWNER", 1, 2);
    }

     private IEnumerator SpawnRoutine(){ 
     while(StopSpawing == false)
        {
            yield return new WaitForSeconds(2);
            float random = Random.Range(-9.5f, 9.5f);
            Vector3 PosToSpawn = new Vector3(randomX, 7, 0);
            GameObject newEnemy = Instantiate(enemyprefab, PosToSpawn, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            
        }
    }

    void SPAWNER()
    {
        float random = Random.Range(-9.5f, 9.5f);
        Vector3 PosToSpawn = new Vector3(randomX, 7, 0);
        Instantiate(enemyprefab, PosToSpawn, enemyprefab.transform.rotation);

        
    }

    public void OnPlayerDeath()
    {
        StopSpawing = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
