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

        private Rigidbody2D _rb;
        private Transform _player;

        void Awake()
        {
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

            if(distanceToPlayer < _chaseDistance)
                Chase();
        }

        void Attack()
        {
            _rb.velocity = Vector2.zero;
        }
        
        void Chase()
        {
            _rb.velocity = (_player.position - transform.position).normalized * _speed * Time.deltaTime;
        }
    }
}