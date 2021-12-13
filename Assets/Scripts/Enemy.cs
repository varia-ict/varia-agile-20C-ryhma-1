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
    public Rigidbody rb;

    // Variables
    public bool CD = false;
    private IEnumerator Coroutine;
    private float dist;
    public float moveSpeed;
    public float howclose;
    public float damage;
    public int hitRange = 10;


    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.constraints = RigidbodyConstraints.FreezePositionX;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        rb.isKinematic = true;
    }

    // Update is called once per frame
    public void Update()
    {

        dist = Vector3.Distance(player.position, transform.position);

        if (dist <= howclose)
        {
            animator.SetBool("idle", false);
            animator.SetBool("BattleIdle", true);
            animator.SetBool("Flying", true);
            rb.constraints = RigidbodyConstraints.None;
            rb.isKinematic = false;
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }

        if (dist >= howclose)
        {
            animator.SetBool("Flying", false);
            animator.SetBool("BattleIdle", false);
        }

        if (dist <= 1.5f && CD == false)
        {
            // Do damage when close to player
            GetComponent<Animator>().SetTrigger("Attack1");
            Attack();
            CD = true;
            Coroutine = CoolDown();
            StartCoroutine(Coroutine);
        }        
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(3);
        CD = false;
    }

    void Attack()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 origin = transform.position;

        if (Physics.Raycast(origin, forward, out hit, hitRange))
        {
            if (hit.transform.gameObject.tag == "Player" && CD == false)
            {

                hit.transform.gameObject.SendMessage("TakeDamage", 10);
                Vector3 orward = transform.TransformDirection(Vector3.forward) * 10;
                CD = true;
                Coroutine = CoolDown();
                StartCoroutine(Coroutine);

            }
        }
    }
}