using UnityEngine;

public class RedBullet : MonoBehaviour
{
    [Header("移動速度")]
    public float speed = 6f;

    [Header("寿命（画面外対策）")]
    public float lifetime = 5f;

    private Vector2 direction;

    void Start()
    {
        Destroy(gameObject, lifetime); // 5秒後に自動削除
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    /// <summary>
    /// 弾の進行方向を外部から設定する
    /// </summary>
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>()?.TakeDamage();
            Destroy(gameObject);
        }
    }
}
