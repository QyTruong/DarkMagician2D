using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    private FlyBoss _boss;

    public MoveCommand(FlyBoss boss)
    {
        this._boss = boss;
    }

    public void execute()
    {
        this._boss.Move();
    }
}
