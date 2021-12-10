using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private int hitRange = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Melee();
        }
    }
    void Melee()
    {
        
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 origin = transform.position;
        RaycastHit hit;
        
       

        if (Physics.Raycast(origin, forward, out hit, hitRange))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                hit.transform.gameObject.SendMessage("TakeDamage", 30);
            }
        }
    }
}
