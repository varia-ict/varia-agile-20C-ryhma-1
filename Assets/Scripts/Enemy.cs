using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Variables
    private Rigidbody enemyRb;
<<<<<<< HEAD
    public Transform player;

    private float dist;
    public float moveSpeed;
    public float howclose;

=======
    public GameObject player;
>>>>>>> 4c26bd9b32cf66aaa533d6d0fe4caf84d275b40e

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);

        if (dist <= howclose)
        { 
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }

        if(dist <= 1.5f)
        {
            // Do damage when close to player
        }

<<<<<<< HEAD
=======
        enemyRb.AddForce(lookDirection * enemySpeed * Time.deltaTime);
>>>>>>> 4c26bd9b32cf66aaa533d6d0fe4caf84d275b40e
    }
}
