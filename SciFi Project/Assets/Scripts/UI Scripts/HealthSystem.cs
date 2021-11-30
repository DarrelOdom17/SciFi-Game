using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [Tooltip("Maximum amount of health")] public int MaxHealth = 30;
    [Tooltip("Starting amount of health")] public int startingHealth = 30;

    public int CurrentHealth;

    Text HealthText;


    // Start is called before the first frame update
    void Start()
    {
        startingHealth = MaxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;

        if (CurrentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void HandleDeath()
    {
        if(gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
