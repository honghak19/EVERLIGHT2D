using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    private PlayerController playerController;

    [Header("Attack Settings")]
    public GameObject attackArea;            // GameObject chứa BoxCollider2D (isTrigger)
    public Transform attackPoint;            // Gốc để dịch chuyển collider
    public float attackDelay = 0.01f;         // Thời gian sau khi vung kiếm mới bật collider
    public float attackDuration = 0.02f;      // Thời gian vùng đánh tồn tại

    [Header("Hướng dịch chuyển vùng đánh")]
    public Vector2 offsetUp = new Vector2(0, 0.5f);
    public Vector2 offsetDown = new Vector2(0, -0.5f);
    public Vector2 offsetLeft = new Vector2(-0.5f, 0);
    public Vector2 offsetRight = new Vector2(0.5f, 0);

    private bool isAttacking = false;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        if (attackArea != null)
            attackArea.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isAttacking)
        {
            Attack("Attack");
        }
    }

    void Attack(string baseName)
    {
        isAttacking = true;

        string direction = GetDirectionSuffix();
        string animName = baseName + "_" + direction;

        // Play animation theo hướng
        animator.Play(animName);

        // Di chuyển vùng đánh theo hướng
        UpdateAttackDirection(direction);

        // Bật vùng gây sát thương đúng lúc
        Invoke(nameof(EnableAttackArea), attackDelay);
        Invoke(nameof(DisableAttackArea), attackDelay + attackDuration);

        // Reset trạng thái tấn công sau khi xong
        Invoke(nameof(ResetAttackState), attackDelay + attackDuration + 0.05f);
    }

    void UpdateAttackDirection(string dir)
    {
        if (attackPoint == null) return;

        switch (dir)
        {
            case "Up":
                attackPoint.localPosition = offsetUp;
                break;
            case "Down":
                attackPoint.localPosition = offsetDown;
                break;
            case "Left":
                attackPoint.localPosition = offsetLeft;
                break;
            case "Right":
                attackPoint.localPosition = offsetRight;
                break;
        }
    }

    void EnableAttackArea()
    {
        if (attackArea != null)
            attackArea.SetActive(true);
    }

    void DisableAttackArea()
    {
        if (attackArea != null)
            attackArea.SetActive(false);
    }

    void ResetAttackState()
    {
        isAttacking = false;
    }

    string GetDirectionSuffix()
    {
        float x = animator.GetFloat("LastHorizontal");
        float y = animator.GetFloat("LastVertical");

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            return x > 0 ? "Right" : "Left";
        }
        else
        {
            return y > 0 ? "Up" : "Down";
        }
    }

}
