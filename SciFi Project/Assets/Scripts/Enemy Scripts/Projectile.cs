using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Values")]
    [Tooltip("Projectile Speed")]
    public float speed = 40f;
    [Tooltip("Damage amount")]
    public int damage = 5;
    [Tooltip("Lifetime of the projectile (used to clean-up unneeded objects)")]
    public float lifetime = 3f;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
