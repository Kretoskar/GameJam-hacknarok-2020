using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infrastructure.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private float _attackTime;
        [SerializeField] private float _dashTime;
        [SerializeField] [Range(0,1000)] private float _speed = 5;
        [SerializeField] private float _attackRange = 0.5f;
        [SerializeField] private float _circleOverlapRadius = 1;
        [SerializeField] private string _enemyLayer = "Enemy";
            
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

        private void DealDamage()
        {
            int layerMask = (1 << LayerMask.NameToLayer(_enemyLayer));
            
            List<Collider2D> hitColliders = Physics2D.OverlapCircleAll(
                (Vector2) transform.position + _playerInput.DirectionFromPlayerToMouse * _attackRange,
                _circleOverlapRadius, layerMask).ToList();
            
            print(hitColliders.Count);
        }

        private IEnumerator AttackCoroutine()
        {
            _mover.CanMove = false;
            _playerInput.CanAttack = false;
            
            float currentTime = 0;

            while (true)
            {
                currentTime += Time.deltaTime;
                
                if(currentTime >= _dashTime)
                    break;
                
                yield return null;
            }

            _rb.velocity = Vector2.zero;
            
            DealDamage();
            
            while (true)
            {
                currentTime += Time.deltaTime;

                _rb.velocity = _playerInput.DirectionFromPlayerToMouse * _speed * Time.deltaTime;

                if(currentTime >= _attackTime)
                    break;
                
                yield return null;
            }

            _mover.CanMove = true;
            _playerInput.CanAttack = true;
        }
    }
}
