using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SparkBullet : Bullet
{
    public override void SetupBullet(Vector3 startPos, Vector3 target, Entity owner)
    {
        base.SetupBullet(startPos, target, owner);

        transform.position = startPos;
        _dir = target;
    }

    private void OnEnable()
    {
        Invoke(nameof(Disable), 3f);
    }

    protected override void Update()
    {
        base.Update();


        if (_isMove)
        {
            transform.right = _rb.velocity;
        }
    }
}
