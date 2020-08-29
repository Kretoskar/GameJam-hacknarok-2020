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
        [SerializeField] private float _attackCooldown = 1;

        private bool _isAttacking;
        
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
                if(!_isAttacking)
                    Attack();
                return;
            }

            if (distanceToPlayer < _chaseDistance)
            {
                StopAllCoroutines();
                _isAttacking = false;
                
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

            StartCoroutine(AttackCoroutine());
        }

        private IEnumerator AttackCoroutine()
        {
            _isAttacking = true;
            
            while (true)
            {
                _enemyAnimations.Attack();
                yield return new WaitForSeconds(_attackCooldown);
            }
        }

        void Chase()
        {
            _enemyAnimations.IsMoving = true;
            
            var desiredVelocity = (_player.position - transform.position).normalized
                                  * _speed * Time.deltaTime;

            _rb.velocity = desiredVelocity;
            _enemyAnimations.Horizontal = desiredVelocity.x;
            _enemyAnimations.Vertical = desiredVelocity.y;
        }
    }
}