using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;   // 青弾プレハブ
    public float spawnInterval = 1.5f; // 発射間隔
    public Vector2 fireDirection = Vector2.left; // 発射方向（左へ）

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