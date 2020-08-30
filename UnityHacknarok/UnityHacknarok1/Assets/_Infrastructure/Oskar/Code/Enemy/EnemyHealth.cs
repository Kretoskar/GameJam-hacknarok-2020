using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using Infrastructure.Enemy;
using Infrastructure.LevelManagement;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _addPointsOnDeath = 10;
    [SerializeField] private int _addTimeOnDeath = 10;
    
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

        ScoreManager.Instance.CurrentScore += _addPointsOnDeath;
        Timer.Instance.AddTime(_addTimeOnDeath);
        
        Destroy(gameObject);
    }
}