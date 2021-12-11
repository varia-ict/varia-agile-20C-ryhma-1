using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // References
    public Transform player;
    public Enemy enemy;
    public Animator animator;

    // Variables
    private float dist;
    public float moveSpeed;
    public float howclose;
    public float attackCooldown;
    public float timeBetweenAttacks = 1;
    public float damage;

    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {

        animator.SetBool("idle", true);
        dist = Vector3.Distance(player.position, transform.position);

        if (dist <= howclose)
        {
            animator.SetBool("idle", false);
            animator.SetBool("BattleIdle", true);
            animator.SetBool("Flying", true);
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }

        if (dist >= howclose)
        {
            animator.SetBool("Flying", false);
            animator.SetBool("BattleIdle", false);
        }

        if (dist <= 1.5f)
        {
            // Do damage when close to player
            GetComponent<Animator>().SetTrigger("Attack1");
        }

        if (timeBetweenAttacks > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
        else if (timeBetweenAttacks <= 0)
        {
            Attack();
            timeBetweenAttacks = attackCooldown;
        }
    }

    public void Attack()
    {
        
    }

}