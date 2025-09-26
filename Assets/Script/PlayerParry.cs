using UnityEngine;

public class PlayerParry : MonoBehaviour
{
    [Header("パリィ設定")]
    public float parryDuration = 0.3f;   // 発動時間
    public float cooldown = 1f;          // クールタイム

    [Header("発光エフェクト")]
    public SpriteRenderer spriteRenderer;
    public Color parryColor = Color.white;  // パリィ時の発光色
    private Color defaultColor;

    [Header("判定範囲")]
    public GameObject parryHitbox; // 発光範囲の当たり判定 (子オブジェクトで用意)

    private bool isParrying = false;
    private bool isOnCooldown = false;

    void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        defaultColor = spriteRenderer.color;

        // 最初は判定オフ
        parryHitbox.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !isParrying && !isOnCooldown)
        {
            StartCoroutine(ParryRoutine());
        }
    }

    private System.Collections.IEnumerator ParryRoutine()
    {
        isParrying = true;

        // 発光＆判定オン
        spriteRenderer.color = parryColor;
        parryHitbox.SetActive(true);

        yield return new WaitForSeconds(parryDuration);

        // 発光解除＆判定オフ
        spriteRenderer.color = defaultColor;
        parryHitbox.SetActive(false);

        isParrying = false;
        isOnCooldown = true;

        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
    }
}
