using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.coyoteTimer;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        stateTimer -= Time.deltaTime;

        if (xInput != 0)
            player.SetVelocity(xInput * player.moveSpeed * 0.8f, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && (player.doublejump == true || stateTimer <= 0)) 
            stateMachine.ChangeState(player.jumpState);

        if (player.GroundCheck())
            stateMachine.ChangeState(player.idleState);

    }
}
