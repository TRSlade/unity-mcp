using UnityEngine;

public class ZeusController : MonoBehaviour
{
    public GameObject lightningBoltPrefab;
    public float throwInterval = 2f;
    public float boltSpeed = 10f;
    public Transform target;

    private float nextThrowTime;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        nextThrowTime = Time.time + throwInterval;
    }

    void Update()
    {
        if (Time.time >= nextThrowTime && target != null)
        {
            ThrowLightningBolt();
            nextThrowTime = Time.time + throwInterval;
        }

        // Flip sprite based on target position
        if (target != null)
        {
            spriteRenderer.flipX = target.position.x > transform.position.x;
        }
    }

    void ThrowLightningBolt()
    {
        // Calculate direction to target
        Vector2 direction = ((Vector2)target.position - (Vector2)transform.position).normalized;
        
        // Create the lightning bolt
        GameObject bolt = Instantiate(lightningBoltPrefab, transform.position, Quaternion.identity);
        
        // Set the bolt's velocity
        Rigidbody2D rb = bolt.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * boltSpeed;
        }
        
        // Rotate the bolt to face the direction it's moving
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bolt.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
} 