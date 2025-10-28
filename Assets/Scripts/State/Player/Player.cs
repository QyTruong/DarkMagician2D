using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public PlayerStateMachine stateMachine { get; private set; }


    public PlayerIdleState idleState { get; private set; }
    public PlayerRunState runState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerDeadState deadState { get; private set; }


    [Header("Player info")]
    public bool doublejump;
    public float moveSpeed;
    public float jumpForce;
    public float dashSpeed;
    public float dashDuration;
    public float _dashDir { get; private set; }
    private float _dashCooldown = 1f;
    private float _dashTimer;

    [Header("Weapon")]
    public OrbController orb;

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new PlayerStateMachine();
        orb = GetComponentInChildren<OrbController>();

        idleState = new PlayerIdleState(stateMachine, this, "idle");
        runState = new PlayerRunState(stateMachine, this, "run");
        jumpState = new PlayerJumpState(stateMachine, this, "jump");
        airState = new PlayerAirState(stateMachine, this, "air");
        dashState = new PlayerDashState(stateMachine, this, "dash");
        deadState = new PlayerDeadState(stateMachine, this, "dead");
    }

    protected override void Start()
    {
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        _dashTimer -= Time.deltaTime;

        stateMachine.currentState.Update();

        if (stats.currentHealth <= 0)
        {
            stateMachine.ChangeState(deadState);
            Invoke("Decay", .5f);
        }

        CheckAttackInput();
        CheckDashInput();
    }

    #region Input
    private void CheckAttackInput()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            orb.Shoot(GetShootDirection());
            AudioManager.Instance.PlaySFX(AudioManager.Instance.playerShootSFX);
        }
    }

    private Vector2 GetShootDirection()
    {
        Vector2 dir = new Vector2(facingDir, 0);

        float angle = 90f;
        if (Input.GetKey(KeyCode.W))
        {
            dir = Quaternion.Euler(0, 0, angle) * new Vector2(1, 0);
            if (Input.GetKey(KeyCode.D))
                dir = Quaternion.Euler(0, 0, angle - 35f) * new Vector2(1, 0);
            else if (Input.GetKey(KeyCode.A))
                dir = Quaternion.Euler(0, 0, angle + 35f) * new Vector2(1, 0);
        }
        return dir;
    }

    private void CheckDashInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _dashTimer <= 0)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.playerDashSFX);

            _dashDir = Input.GetAxisRaw("Horizontal");

            if (_dashDir == 0)
                _dashDir = facingDir;

            stateMachine.ChangeState(dashState);
            _dashTimer = _dashCooldown;
        }
    }
    #endregion
}
