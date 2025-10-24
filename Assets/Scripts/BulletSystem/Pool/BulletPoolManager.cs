using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    private static BulletPoolManager instance;
    public static BulletPoolManager Instance { get => instance; }
    private Dictionary<GameObject, BulletPool> _dictPools = new Dictionary<GameObject, BulletPool>();

    private void Awake()
    {
        if (Instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    
    public GameObject GetFromPool(GameObject obj)
    {
        if (!_dictPools.ContainsKey(obj))
        {
            _dictPools.Add(obj, new BulletPool(obj));
        }
        return _dictPools[obj].SpawnBullet();
    }
}
