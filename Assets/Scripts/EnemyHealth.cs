using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;
    public int maxHealth;

    public GameObject healthBarUI;
    public Slider slider;
    public Animator animator;

    void Start()
    {
        enemyHealth = maxHealth;
        slider.value = CalculateHealth();
    }

    void Update()
    {
        slider.value = CalculateHealth();

        if (enemyHealth < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        if(enemyHealth > maxHealth)
        {
            enemyHealth = maxHealth;
        }
    }

    float CalculateHealth()
    {
        return enemyHealth / maxHealth;
    }

    void TakeDamage(int damageAmount)
    {
        enemyHealth = enemyHealth - damageAmount;
        if (enemyHealth < 0)
        {
            // add your death things here
            animator.SetBool("Die", true);
            Destroy(gameObject);
        }
    }
}
