using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReturnToBulletPool : MonoBehaviour
{
    public BulletPool pool;

    private void OnDisable()
    {
        pool.AddToBulletPool(gameObject);
    }
}
