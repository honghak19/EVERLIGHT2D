using UnityEngine;
using UnityEngine.AI;

public class BossMOSSE3 : MonoBehaviour
{
    [Header("Target & Components")]
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [Header("Stats")]
    public float attackRange = 1.5f;
    public float attackCooldown = 1f;
    public int maxHealth = 100;
    private int currentHealth;

    private bool isAttacking = false;
    private bool isDead = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;

        currentHealth = maxHealth;
    }

    void Update()
    {
        if (isDead || target == null) return;

        float distance = Vector2.Distance(transform.position, target.position);

        // Flip hướng
        Flip();

        if (distance <= attackRange)
        {
            agent.isStopped = true;
            animator.SetBool("RUN1", false);

            if (!isAttacking)
                StartCoroutine(Attack());
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            animator.SetBool("RUN1", true);
        }
    }

    void Flip()
    {
        if (target.position.x < transform.position.x)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }

    System.Collections.IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetTrigger("ATK1");
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        animator.SetBool("HURT1", true);
        Invoke(nameof(ResetHurt), 0.3f);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void ResetHurt()
    {
        animator.SetBool("MosseHURT", false);
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("MosseDEAD");
        agent.isStopped = true;
        Destroy(gameObject, 2f); // Tùy chọn: hủy sau 2 giây
    }
}
