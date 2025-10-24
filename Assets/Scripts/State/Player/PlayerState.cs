using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected string animBoolName;

    public float xInput;
    public float yInput;
    protected float stateTimer;

    protected Rigidbody2D rb;

    protected PlayerState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.player = _player;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        rb = player.rb;
        player.anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;

        xInput = Input.GetAxisRaw("Horizontal");
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }
}
