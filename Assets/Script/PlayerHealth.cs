using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("体力設定")]
    public int maxHP = 3;
    private int currentHP;

    [Header("無敵時間設定")]
    public float invincibleDuration = 1f;
    private bool isInvincible = false;

    private SpriteRenderer spriteRenderer;
    private Color defaultColor;

    void Start()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null) defaultColor = spriteRenderer.color;
    }

    public void TakeDamage()
    {
        if (isInvincible) return;

        currentHP--;
        Debug.Log("被弾！ 残りHP: " + currentHP);

        if (currentHP <= 0)
        {
            Debug.Log("ゲームオーバー！プレイヤー撃墜");
            // ここでリトライ処理やゲームオーバー画面に繋げる
        }
        else
        {
            StartCoroutine(InvincibilityRoutine());
        }
    }

    private System.Collections.IEnumerator InvincibilityRoutine()
    {
        isInvincible = true;

        // 点滅演出（オプション）
        if (spriteRenderer != null)
        {
            for (int i = 0; i < 5; i++)
            {
                spriteRenderer.color = new Color(1, 1, 1, 0.3f);
                yield return new WaitForSeconds(invincibleDuration / 10f);
                spriteRenderer.color = defaultColor;
                yield return new WaitForSeconds(invincibleDuration / 10f);
            }
        }
        else
        {
            yield return new WaitForSeconds(invincibleDuration);
        }

        isInvincible = false;
    }
}