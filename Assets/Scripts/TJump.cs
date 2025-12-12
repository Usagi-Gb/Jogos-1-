using UnityEngine;

public class TJump : MonoBehaviour
{   
    [Header("Combat Settings")]
    public float damage = 0f;
    public float attackCooldown = 1f;
    public float knockbackForce = 15f;
    private Rigidbody2D rb;
    private float lastAttackTime;
    public Transform visual;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = visual.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TryAttackPlayer(collision.gameObject);
        }
    }

    void TryAttackPlayer(GameObject player)
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                Vector2 knockbackDirection = (player.transform.position - transform.position).normalized;
                playerHealth.TakeDamage(damage, knockbackDirection, knockbackForce);
                lastAttackTime = Time.time;
            }
        }
    }
    void Update(Collision2D collision){
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.isTouching;
        }
    }
}