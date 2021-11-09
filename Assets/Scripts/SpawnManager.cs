using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //public GameObject enemyprefab;
    public List<GameObject> mushrooms;
    private float randomX;
    
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SPAWNER", 1, 2);
    }


    void SPAWNER()
    {
        float random = Random.Range(-9.5f, 9.5f);
        Vector3 PosToSpawn = new Vector3(randomX, 7, 0);
        //Instantiate(enemyprefab, PosToSpawn, enemyprefab.transform.rotation);
    }
}
