using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;   // �e�v���n�u
    public float spawnInterval = 1.5f; // ���ˊԊu
    public Vector2 fireDirection = Vector2.left; // ���˕����i���ցj

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnBullet();
            timer = 0f;
        }
    }

    void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<EnergyBullet>().SetDirection(fireDirection);
    }
}