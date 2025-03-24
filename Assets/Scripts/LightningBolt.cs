using UnityEngine;

public class LightningBolt : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 20f;
    public float lifetime = 3f;
    public GameObject hitEffect;

    void Start()
    {
        // Destroy the bolt after lifetime seconds
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Deal damage to player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            
            // Destroy the bolt on hit
            Destroy(gameObject);
        }

        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
    }
} 