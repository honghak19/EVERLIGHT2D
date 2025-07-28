using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float sprintMultiplier = 1.5f; // Tăng tốc khi nhấn Space

    private Vector2 movement;
    private Vector2 lastMoveDir; // Hướng cuối cùng

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Cập nhật hướng cuối cùng nếu đang di chuyển
        if (movement != Vector2.zero)
        {
            lastMoveDir = movement;
        }

        // Set các thông số cho animator
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Run", movement.sqrMagnitude);

        // Gửi hướng cuối cùng để dùng cho Idle
        animator.SetFloat("LastHorizontal", lastMoveDir.x);
        animator.SetFloat("LastVertical", lastMoveDir.y);
    }

    void FixedUpdate()
    {
        float currentSpeed = moveSpeed;

        // Nếu giữ phím Space thì tăng tốc
        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed *= sprintMultiplier;
        }

        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }
}
