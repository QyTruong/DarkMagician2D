using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStats : MonoBehaviour
{
    public Stats damage;
    public Stats defence;
    public Stats health;

    public int currentHealth;

    public event Action OnValueChanged;

    public virtual void Start()
    {
        currentHealth = GetMaxHealth();
    }

    public virtual void DoDamage(CharacterStats target)
    {
        int totalDamage = ResistDamage(target, damage.GetValue());
        target.TakeDamage(totalDamage);
    }

    public virtual void TakeDamage(int damage)
    {
        DecreaseHealth(damage);
    }

    public virtual int ResistDamage(CharacterStats target, int totalDamage)
    {
        totalDamage -= target.defence.GetValue();
        return totalDamage;
    }

    public int GetMaxHealth() => health.GetValue();

    public void DecreaseHealth(int damage)
    {
        currentHealth -= damage;
        OnValueChanged?.Invoke();
    }
}
