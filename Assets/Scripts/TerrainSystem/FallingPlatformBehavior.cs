using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformBehavior : MonoBehaviour, ITerrainBehavior
{
    private Terrain terrain;
    private Rigidbody2D rb;
    private bool canFall = false;
    private float timerDelayFall;
    private float delayBeforeFall = .3f;

    public void Setup(Terrain terrain)
    {
        this.terrain = terrain;
        rb = terrain.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        timerDelayFall = 0;
    }


    public void Execute(Terrain terrain)
    {
        if (canFall)
        {
            timerDelayFall += Time.deltaTime;
            Debug.Log(timerDelayFall);

            if (timerDelayFall >= delayBeforeFall)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = 7;
                terrain.enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canFall = true;
        }
    }
}
