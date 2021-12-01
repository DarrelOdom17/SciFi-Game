using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 20f;
    private int killCount;

    private UIManager manager;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<UIManager>();
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
