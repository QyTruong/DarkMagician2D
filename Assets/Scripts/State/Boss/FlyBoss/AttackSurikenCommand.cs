using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSurikenCommand : Command
{
    private FlyBoss _boss;

    public AttackSurikenCommand(FlyBoss boss)
    {
        this._boss = boss;
    }

    public void execute()
    {
        this._boss.AttackSuriken();
    }
}
