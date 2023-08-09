using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;

    private float lifetime = 5f;

    public float force;
    public float damage;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        if (!player.gameObject.GetComponent<PlayerController>().isInvincible)
        {
            Vector3 playerDirection = player.position - transform.position;
            rb.velocity = new Vector2(playerDirection.x, playerDirection.y).normalized * force;

            float playerRotation = Mathf.Atan2(-playerDirection.y, -playerDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, playerRotation);
        }
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 knockbackDirection = player.gameObject.GetComponent<Rigidbody2D>().transform.position - transform.position;
            knockbackDirection.Normalize();

            player.gameObject.GetComponent<PlayerController>().TakeDamage(damage, knockbackDirection);
            Destroy(gameObject);
        }
    }
}
