using System.Collections;
using System.Collections.Generic;
using Infrastructure.Player;
using UnityEngine;

namespace Infrastructure.Enemy
{
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] [Range(0,1000)] private float _speed = 5;
        [SerializeField] private float _chaseDistance = 5;
        [SerializeField] private float _attackDistance = 5;

        private EnemyAnimations _enemyAnimations;
        private Rigidbody2D _rb;
        private Transform _player;

        void Awake()
        {
            _enemyAnimations = GetComponent<EnemyAnimations>();
            _rb = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            _player = FindObjectOfType<PlayerControler>().transform;
        }

        void Update()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

            if (distanceToPlayer < _attackDistance)
            {
                Attack();
                return;
            }

            if (distanceToPlayer < _chaseDistance)
            {
                Chase();
                return;
            }

            _enemyAnimations.IsMoving = false;
            _rb.velocity = Vector2.zero;
        }

        void Attack()
        {
            _enemyAnimations.IsMoving = false;
            
            _rb.velocity = Vector2.zero;
        }

        void Chase()
        {
            _enemyAnimations.IsMoving = true;
            
            var desiredVelocity = (_player.position - transform.position).normalized * _speed * Time.deltaTime;

            _rb.velocity = desiredVelocity;
            _enemyAnimations.Horizontal = desiredVelocity.x;
            _enemyAnimations.Vertical = desiredVelocity.y;
        }
    }
}