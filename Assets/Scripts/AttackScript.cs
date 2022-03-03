using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [Header("Damage related")]
    public float damage = 25;
   
    public int hitRange = 10;
    [Header("gameobjects")]
    public Animator anim;
    public bool CD = false;
    private IEnumerator Coroutine;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10000;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
            anim.SetBool("attack", true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("attack", false);
        }
        
    }
    void Attack()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 origin = transform.position;

        if (Physics.Raycast(origin, forward, out hit, hitRange))
        {
            
            Debug.DrawRay(transform.position, forward, Color.red, 100);
            if (hit.transform.gameObject.tag == "Enemy" && CD == false)
            {
                
                hit.transform.gameObject.SendMessage("TakeDamage", damage);
                Vector3 orward = transform.TransformDirection(Vector3.forward) * 10;
                CD = true;
                Coroutine = CoolDown();
                StartCoroutine(Coroutine);

            }
        }
    }
    private IEnumerator CoolDown()
    {
        
        yield return new WaitForSeconds(1);
            CD = false;
    }

        }