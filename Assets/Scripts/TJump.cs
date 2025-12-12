using UnityEngine;

public class TJump : MonoBehaviour
{   
    [Header("Combat Settings")]
    public float damage = 0f;
    public float attackCooldown = 1f;
    public float knockbackForce = 15f; 
    private Rigidbody2D rb;
    private float lastAttackTime;
    
    [Header("Animation & Visuals")]
    public Transform visual; 
    private Animator anim;
    public string isTouchingParamName = "isTouchin"; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (visual != null)
        {
            anim = visual.GetComponent<Animator>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SetTrampolinAnimation(true);
            TryAttackPlayer(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SetTrampolinAnimation(false);
        }
    }

    void SetTrampolinAnimation(bool isTouching)
    {
        if (anim != null)
        {
            anim.SetBool(isTouchingParamName, isTouching);
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
                knockbackDirection.y = 1f; 
                playerHealth.TakeDamage(damage, knockbackDirection, knockbackForce);
                lastAttackTime = Time.time;
            }
        }
    }
}