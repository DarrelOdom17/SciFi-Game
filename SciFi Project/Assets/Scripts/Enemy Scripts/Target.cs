using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 20f;

    private PauseMenu manager;
    private WinGame winManager;

    private void Start()
    {
        manager = GameObject.Find("GameUI").GetComponent<PauseMenu>();
        manager.enemyCount++;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        manager.enemyCount--;
        Destroy(gameObject);
    }
}
