using UnityEngine;

public class PlayerMovementMouse : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;

    private Vector2 targetPosition;
    private bool isMoving = false;
    private Vector2 movement;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }
        movement = (targetPosition - rb.position).normalized;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Run", isMoving ? 1f : 0f);
    }

    void FixedUpdate()
    {
        if (isMoving == true)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            if (Vector2.Distance(rb.position, targetPosition) <= 0.1f)
            {
                isMoving = false;
            }
        }
    }
}
