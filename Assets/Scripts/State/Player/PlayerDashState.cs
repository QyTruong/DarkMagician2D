using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
    }

    public override void Exit()
    {
        base.Exit();

        rb.velocity = Vector2.zero;
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(player.facingDir * player.dashSpeed, 0);

        if (stateTimer <= 0)
            stateMachine.ChangeState(player.idleState);
    }
}
