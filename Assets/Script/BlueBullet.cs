using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    [Header("移動速度")]
    public float speed = 5f;

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
        // パリィに触れたら吸収
        if (other.CompareTag("Parry"))
        {
            Debug.Log("パリィ成功！");
            Destroy(gameObject);
        }

        // プレイヤー本体に当たった場合（まだHPシステム仮）
        if (other.CompareTag("Player"))
        {
            Debug.Log("青弾に被弾！");
            Destroy(gameObject);
        }
    }
}
