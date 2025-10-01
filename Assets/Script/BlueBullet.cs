using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    [Header("�ړ����x")]
    public float speed = 5f;

    [Header("�����i��ʊO�΍�j")]
    public float lifetime = 5f;

    private Vector2 direction;

    void Start()
    {
        Destroy(gameObject, lifetime); // 5�b��Ɏ����폜
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    /// <summary>
    /// �e�̐i�s�������O������ݒ肷��
    /// </summary>
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �p���B�ɐG�ꂽ��z��
        if (other.CompareTag("Parry"))
        {
            Debug.Log("�p���B�����I");
            Destroy(gameObject);
        }

        // �v���C���[�{�̂ɓ��������ꍇ�i�܂�HP�V�X�e�����j
        if (other.CompareTag("Player"))
        {
            Debug.Log("�e�ɔ�e�I");
            Destroy(gameObject);
        }
    }
}
