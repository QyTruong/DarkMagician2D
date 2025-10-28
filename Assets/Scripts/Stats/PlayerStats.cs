using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    override public void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.playerHurtSFX);
    }
}
