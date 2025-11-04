using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public CharacterStats stats { get; private set; }


    [Header("Collision check")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected float groundCheckDistance;

    public int facingDir = 1;
    public bool facingRight = true;
    public bool isActive;

    public event Action OnFlipped;

    protected virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<CharacterStats>();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }


    #region Velocity
    public virtual void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
    #endregion

    #region Flip
    public virtual void Flip()
    {
        facingDir *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);

        OnFlipped?.Invoke();
    }

    protected virtual void FlipController(float _xVelocity)
    {
        if (_xVelocity < 0 && facingRight)
            Flip();
        else if (_xVelocity > 0 && !facingRight)
            Flip();
    }
    #endregion

    #region Groundcheck
    public bool GroundCheck() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
    protected virtual void OnDrawGizmos()
    {
        if (!groundCheck)
            return;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
    }
    #endregion

    protected virtual void Decay()
    {
        gameObject.SetActive(false);
        isActive = false;
    }

    protected void OnEnable()
    {
        isActive = true;
    }
}
