using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _health;
    public float CurrentHealth => _health;
    /// <summary>
    /// Called when health is reduced to zero
    /// </summary>
    public event Action OnDeath;
    /// <summary>
    /// Causes entity to take damage
    /// </summary>
    /// <param name="amount">Amount of damage to take</param>
    /// <returns>True if the damage killed the entity</returns>
    public bool Damage(float amount)
    {
        _health -= amount;

        if (_health < 0)
        {
            OnDeath?.Invoke();
            return true;
        }

        return false;
    }
}
