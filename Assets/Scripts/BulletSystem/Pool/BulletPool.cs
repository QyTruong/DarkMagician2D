using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    private Stack<GameObject> _pool = new Stack<GameObject>();
    private GameObject _baseBullet;
    private GameObject _bullet;
    private ReturnToBulletPool _returnToPool;


    public BulletPool(GameObject baseObj)
    {
        this._baseBullet = baseObj;
    }

    public GameObject SpawnBullet()
    {
        if (_pool.Count > 0)
        {
            _bullet = _pool.Pop();
            _bullet.SetActive(true);
            return _bullet;
        }

        _bullet = GameObject.Instantiate(_baseBullet);
        _returnToPool = _bullet.AddComponent<ReturnToBulletPool>();
        _returnToPool.pool = this;
        return _bullet;
    }

    public void AddToBulletPool(GameObject bullet)
    {
        _pool.Push(bullet);
    }
}
