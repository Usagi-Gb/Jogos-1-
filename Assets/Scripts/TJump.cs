using UnityEngine;

public class TJump : MonoBehaviour
{   
    [Header("Combat Settings")]
    public float damage = 0f;
    public float attackCooldown = 1f;
    public float knockbackForce = 15f; // Força do "pulo" ou knockback
    private Rigidbody2D rb;
    private float lastAttackTime;
    
    [Header("Animation & Visuals")]
    public Transform visual; 
    private Animator anim;
    public string isTouchingParamName = "isTouchin"; // Nome do seu parâmetro Bool no Animator

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (visual != null)
        {
            anim = visual.GetComponent<Animator>();
        }
    }

    // Chamado no frame em que outro objeto ENTRA no Trigger (o primeiro toque)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 1. LIGA A ANIMAÇÃO
            SetTrampolinAnimation(true);
            
            // 2. Tenta aplicar o dano/pulo (ação)
            TryAttackPlayer(other.gameObject);
        }
    }

    // Chamado no frame em que outro objeto SAI do Trigger
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // DESLIGA A ANIMAÇÃO
            SetTrampolinAnimation(false);
        }
    }

    // Método para ligar/desligar a animação (Bool)
    void SetTrampolinAnimation(bool isTouching)
    {
        if (anim != null)
        {
            // Define o parâmetro Bool no Animator
            anim.SetBool(isTouchingParamName, isTouching);
        }
    }

    // Seu código de ataque/pulo, que é chamado APENAS no OnTriggerEnter2D
    void TryAttackPlayer(GameObject player)
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Aplica o knockback (o "pulo" do trampolim)
                Vector2 knockbackDirection = (player.transform.position - transform.position).normalized;
                // Adicionar uma pequena força vertical para o impulso para cima
                knockbackDirection.y = 1f; 
                
                playerHealth.TakeDamage(damage, knockbackDirection, knockbackForce);
                lastAttackTime = Time.time;
            }
        }
    }
}