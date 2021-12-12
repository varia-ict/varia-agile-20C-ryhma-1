using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool isDead;

    public GameObject healthBarUI;
    public Slider slider;
    public Animator animator;

    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    void Update()
    {
        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        if (health < 0)
        {
            // add your death things here
            animator.SetBool("Attack1", false);
            animator.SetBool("Flying", false);
            animator.SetBool("Battleidle", false);
            animator.SetBool("idle", false);
            animator.SetBool("Die", true);
            IsDead();
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }

    void TakeDamage(int damageAmount)
    {
        health = health - damageAmount;
    }

    void IsDead()
    {
        if (health < 0)
        {
            isDead = true;
            GetComponent<Enemy>().enabled = false;
        }
    }
}
