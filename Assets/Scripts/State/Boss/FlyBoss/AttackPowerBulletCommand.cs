using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerBulletCommand : Command
{
    private FlyBoss _boss;

    public AttackPowerBulletCommand(FlyBoss boss)
    {
        this._boss = boss;
    }

    public void execute()
    {
        this._boss.AttackPowerBullet();
    }
}
