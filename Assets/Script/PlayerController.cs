using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Nhận input từ bàn phím (WASD hoặc mũi tên)
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D hoặc ←/→
        movement.y = Input.GetAxisRaw("Vertical");   // W/S hoặc ↑/↓

        movement.Normalize(); // Giữ tốc độ đều khi đi chéo
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}