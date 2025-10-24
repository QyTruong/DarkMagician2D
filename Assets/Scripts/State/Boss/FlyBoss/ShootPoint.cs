using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    private Player _player;
    private FlyBoss _boss => GetComponentInParent<FlyBoss>();
    [SerializeField] private GameObject _prefabSuriken;
    [SerializeField] private GameObject _prefabPowerBullet;

    private void Start()
    {
        _player = PlayerManager.Instance.player;
    }

    public void SpawnSuriken()
    {
        GameObject suriken = BulletPoolManager.Instance.GetFromPool(_prefabSuriken);
        suriken.GetComponent<SurikenBullet>().SetupBullet(this.transform.position, _player.transform.position, _boss);
    }

    public void SpawnPowerBullet()
    {
        int bulletCount = 12;
        float angleStep = 360f / bulletCount;
        float angle = 0f;

        for (int i = 0; i < bulletCount; i++)
        {
            float dirX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float dirY = Mathf.Sin(angle * Mathf.Deg2Rad);

            GameObject powerBullet = BulletPoolManager.Instance.GetFromPool(_prefabPowerBullet);
            powerBullet.GetComponent<PowerBullet>().SetupBullet(this.transform.position, new Vector3(dirX, dirY, 0).normalized, _boss);

            angle += angleStep;
        }
    }
}
