using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [Header("Bullet info")]
    [SerializeField] protected float bulletSpeed;

    protected Entity _owner;
    protected Animator _anim;
    protected Rigidbody2D _rb;
    protected Vector3 _target;
    protected Vector3 _dir;
    protected bool _isMove;

    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
    }

    public virtual void SetupBullet(Vector3 startPos, Vector3 target, Entity owner)
    {
        this._owner = owner;
        _isMove = true;
    }

    protected virtual void OnDisable()
    {
        CancelInvoke();
    }

    protected virtual void Disable()
    {
        gameObject.SetActive(false);
    }

    protected virtual void Update()
    {
        if (_isMove)
            _rb.velocity = _dir * bulletSpeed;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterStats targetStats = collision.GetComponent<CharacterStats>();
        if (targetStats != null && targetStats != _owner.stats)
        {
            _owner.stats.DoDamage(targetStats);
            Explode();
        }
        if (collision.CompareTag("Ground"))
            Explode();
    }

    protected virtual void Explode()
    {
        _isMove = false;
        _rb.velocity = Vector2.zero;
        this._anim.SetBool("isExplode", true);
        Invoke(nameof(Disable), .7f);
    }
}
