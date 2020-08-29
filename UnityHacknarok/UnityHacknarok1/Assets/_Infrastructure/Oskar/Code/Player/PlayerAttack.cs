using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private float _attackTime;
        [SerializeField] private float _dashTime;
        [SerializeField] [Range(0,1000)] private float _speed = 5;

        private Mover _mover;
        private PlayerInput _playerInput;
        private Rigidbody2D _rb;

        void Awake()
        {
            _mover = GetComponent<Mover>();
            _rb = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            _playerInput = PlayerInput.Instance;
            
            _playerInput.AttackKeyPressed += Attack;
        }
        
        public void Attack()
        {
            StartCoroutine(AttackCoroutine());
        }

        private IEnumerator AttackCoroutine()
        {
            _mover.CanMove = false;
            
            float currentTime = 0;

            while (true)
            {
                currentTime += Time.deltaTime;

                _rb.velocity = _playerInput.DirectionFromPlayerToMouse * _speed * Time.deltaTime;

                if(currentTime >= _dashTime)
                    break;
                
                yield return null;
            }

            _rb.velocity = Vector2.zero;
            
            while (true)
            {
                currentTime += Time.deltaTime;
                
                if(currentTime >= _attackTime)
                    break;

                yield return null;
            }

            _mover.CanMove = true;
        }
    }
}
