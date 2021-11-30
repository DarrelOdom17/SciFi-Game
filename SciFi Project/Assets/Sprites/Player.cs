using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("Max value of health")]
    public int maxHealth = 100;
    [Tooltip("Current Health")]
    public int currentHealth;

    public HealthBar healthBar;
    //public 
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    //public void HandleDeath()
    //{
    //    if (currentHealth <= 0)
    //    {
    //        agent.enabled = false;
    //    }
    //}
}
