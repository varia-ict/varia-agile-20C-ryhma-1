using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public int hitRange = 10;
    public bool CD = false;
    private IEnumerator Coroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }
    void Attack()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 origin = transform.position;

        if (Physics.Raycast(origin, forward, out hit, hitRange))
        {
            if (hit.transform.gameObject.tag == "Enemy" && CD == false)
            {
                hit.transform.gameObject.SendMessage("TakeDamage", 30);
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
