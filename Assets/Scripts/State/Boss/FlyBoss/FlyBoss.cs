using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBoss : Entity
{
    [Header("Boss info")]
    [SerializeField] private float _moveSpeed;

    private Player _player;
    private float _posY;
    public bool finished;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        _player = PlayerManager.Instance.player;
        _posY = this.transform.position.y;
        finished = true;

        anim.SetBool("idle", true);  
    }

    protected override void Update()
    {
        base.Update();

        if (stats.currentHealth <= 0)
        {
            Decay();
        }
    }

    public void AttackSuriken()
    {
        anim.SetTrigger("attackSuriken");
        finished = true;
    }
    
    public void AttackPowerBullet()
    {
        anim.SetTrigger("attackPowerBullet");
        finished = true;
    }

    public void Move()
    {
        Vector3 targetPos = new Vector3(_player.transform.position.x, _posY, 0);

        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, _moveSpeed * Time.deltaTime);

        if (this.transform.position.Equals(targetPos))
            finished = true;
    }

}
