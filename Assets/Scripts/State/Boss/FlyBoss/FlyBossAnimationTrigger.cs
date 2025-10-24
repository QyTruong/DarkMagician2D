using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBossAnimationTrigger : MonoBehaviour
{
    [SerializeField] private ShootPoint _startPos;

    private void ShootSuriken() => _startPos.SpawnSuriken();
    private void ShootPowerBullet() => _startPos.SpawnPowerBullet();
}
