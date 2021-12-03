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
    private Animator animator;

    private float dist;
    public float moveSpeed;
    public float howclose;
    public float hit;
    public int damage;

    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {

        dist = Vector3.Distance(player.position, transform.position);

        if (dist <= howclose)
        {
            animator.Play("Battleidle");
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }

        if (dist <= 1.5f)
        {
            // Do damage when close to player

        }

    }
}