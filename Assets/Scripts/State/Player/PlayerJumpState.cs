using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        player.doublejump = !player.doublejump;
        rb.velocity = new Vector2(rb.velocity.x, player.jumpForce);

        if (player.doublejump)
            rb.velocity = new Vector2(rb.velocity.x, player.jumpForce * 1.2f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (rb.velocity.y < 0)
            stateMachine.ChangeState(player.airState);
    }
}
