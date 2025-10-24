using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SurikenBullet : Bullet
{
    public override void SetupBullet(Vector3 startPos, Vector3 target, Entity owner)
    {
        base.SetupBullet(startPos, target, owner);

        transform.position = startPos;
        _target = target;
        _dir = (this._target - this.transform.position).normalized;
    }
}
