using System.Collections;
using System.Collections.Generic;
using Infrastructure.Enemy;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private Attackable _attackable;
    
    private int _currentHealth;

    void Awake()
    {
        _attackable = GetComponent<Attackable>();

        _attackable.Hit += UpdateHealth;

        _currentHealth = _maxHealth;
    }

    private void UpdateHealth()
    {
        _currentHealth--;
        
        if(_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        _attackable.Hit -= UpdateHealth;
        
        Destroy(gameObject);
    }
}
