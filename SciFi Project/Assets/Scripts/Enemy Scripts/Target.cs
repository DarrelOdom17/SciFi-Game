using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 20f;
    private int killCount;

    public UIManager manager;

    private void Start()
    {
     
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
        if(health <= 0)
        Destroy(gameObject);
        //killCount++;
        manager.UpdateKilledCounterUI();
    }

    public int SetKillCount()
    {
        killCount++;
        return killCount;
    }
}
