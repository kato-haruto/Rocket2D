using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("移動速度")]
    public float moveSpeed = 5f;

    [Header("移動範囲（画面の端を制御）")]
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
        // 入力取得 (WASD/矢印キー両対応)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // 移動処理
        Vector2 newPosition = rb.position + moveInput * moveSpeed * Time.fixedDeltaTime;

        // 画面端でClamp
        float clampedX = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        rb.MovePosition(new Vector2(clampedX, clampedY));
    }
}