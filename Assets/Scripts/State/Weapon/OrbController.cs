using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    [SerializeField] private SparkBullet bulletPrefab;
    private Player _player => GetComponentInParent<Player>();

    public void Shoot(Vector3 shootDir)
    {
        GameObject bullet = BulletPoolManager.Instance.GetFromPool(bulletPrefab.gameObject);
        bullet.GetComponent<SparkBullet>().SetupBullet(this.transform.position, shootDir, _player); 
    } 
}
