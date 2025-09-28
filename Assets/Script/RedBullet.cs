using UnityEngine;

public class RedBullet : MonoBehaviour
{
    [Header("�ړ����x")]
    public float speed = 6f;

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
        // �p���B����͖����i�e�ƈ���ď����Ȃ��j
        if (other.CompareTag("Parry"))
        {
            return;
        }

        // �v���C���[�{�̂ɓ��������ꍇ
        if (other.CompareTag("Player"))
        {
            Debug.Log("�Ԓe�ɔ�e�IHP�����炷�����\��");
            Destroy(gameObject);
        }
    }
}
