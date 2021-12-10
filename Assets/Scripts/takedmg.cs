using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takedmg : MonoBehaviour
{



    private int health = 100;

    void TakeDamage(int damageAmount)
    {
        health = health - damageAmount;

        // We should also check if the health is still greater than 0 
        // in order to determine whether enemy is still alive or not

        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}