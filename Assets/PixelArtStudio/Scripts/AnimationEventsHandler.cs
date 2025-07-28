using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(horizontal, vertical).normalized;

        // Gửi thông số hướng
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

        // Xác định đang di chuyển hay không
        bool isMoving = Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f;

        // Gửi bool Walk
        animator.SetBool("Walk", isMoving);

        // Nếu muốn hỗ trợ chạy
        if (Input.GetKey(KeyCode.LeftShift) && isMoving)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Walk", false);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        // Block ví dụ (B để block)
        if (Input.GetKey(KeyCode.B))
        {
            animator.SetBool("Block", true);
        }
        else
        {
            animator.SetBool("Block", false);
        }

        // Stunned (ví dụ gọi từ logic khác)
        // animator.SetBool("Stunned", isStunned);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
