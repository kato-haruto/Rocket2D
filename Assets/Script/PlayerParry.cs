using UnityEngine;

public class PlayerParry : MonoBehaviour
{
    [Header("�p���B�ݒ�")]
    public float parryDuration = 0.3f;   // ��������
    public float cooldown = 1f;          // �N�[���^�C��

    [Header("�����G�t�F�N�g")]
    public SpriteRenderer spriteRenderer;
    public Color parryColor = Color.white;  // �p���B���̔����F
    private Color defaultColor;

    [Header("����͈�")]
    public GameObject parryHitbox; // �����͈͂̓����蔻�� (�q�I�u�W�F�N�g�ŗp��)

    private bool isParrying = false;
    private bool isOnCooldown = false;

    void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        defaultColor = spriteRenderer.color;

        // �ŏ��͔���I�t
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

        // ����������I��
        spriteRenderer.color = parryColor;
        parryHitbox.SetActive(true);

        yield return new WaitForSeconds(parryDuration);

        // ��������������I�t
        spriteRenderer.color = defaultColor;
        parryHitbox.SetActive(false);

        isParrying = false;
        isOnCooldown = true;

        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
    }
}
