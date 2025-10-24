using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBullet : Bullet
{
    public override void SetupBullet(Vector3 startPos, Vector3 target, Entity owner)
    {
        base.SetupBullet(startPos, target, owner);
        transform.position = startPos;
        _dir = target;
    }
}
