using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Variables
    public Rigidbody enemyRb;
    public Transform player;
    public Enemy enemy;

    private float dist;
    public float moveSpeed;
    public float howclose;
    public float hit;
    public int damage;
    public int enemyHealth;
    public bool isAlive;


    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

        dist = Vector3.Distance(player.position, transform.position);

        if (dist <= howclose)
        {
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }

        if (dist <= 1.5f)
        {
            // Do damage when close to player
            
        }

    }

    public bool IsDead()
    {
        if (enemyHealth != 0)
        {
            isAlive = true;
        }


        if (enemyHealth <= 0)
        {
            isAlive = false;
        }

        return false;
    }

}