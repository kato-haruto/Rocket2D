using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("�ړ����x")]
    public float moveSpeed = 5f;

    [Header("�ړ��͈́i��ʂ̒[�𐧌�j")]
    public Vector2 minBounds = new Vector2(-8f, -4.5f);
    public Vector2 maxBounds = new Vector2(8f, 4.5f);

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ���͎擾 (WASD/���L�[���Ή�)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // �ړ�����
        Vector2 newPosition = rb.position + moveInput * moveSpeed * Time.fixedDeltaTime;

        // ��ʒ[��Clamp
        float clampedX = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        rb.MovePosition(new Vector2(clampedX, clampedY));
    }
}