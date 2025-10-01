using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("�̗͐ݒ�")]
    public int maxHP = 3;
    private int currentHP;

    [Header("���G���Ԑݒ�")]
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
        Debug.Log("��e�I �c��HP: " + currentHP);

        if (currentHP <= 0)
        {
            Debug.Log("�Q�[���I�[�o�[�I�v���C���[����");
            // �����Ń��g���C������Q�[���I�[�o�[��ʂɌq����
        }
        else
        {
            StartCoroutine(InvincibilityRoutine());
        }
    }

    private System.Collections.IEnumerator InvincibilityRoutine()
    {
        isInvincible = true;

        // �_�ŉ��o�i�I�v�V�����j
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