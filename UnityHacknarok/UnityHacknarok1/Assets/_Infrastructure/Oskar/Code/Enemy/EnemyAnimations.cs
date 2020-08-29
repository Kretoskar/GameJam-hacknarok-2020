using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Enemy
{
    public class EnemyAnimations : MonoBehaviour
    {
        [SerializeField] private string _horizontalKey = "Horizontal";
        [SerializeField] private string _verticalKey = "Vertical";

        [SerializeField] private string _isMovingKey = "IsMoving";
        [SerializeField] private string _attackKey = "Attack";
        
        private Animator _animator;
        
        public bool IsMoving;
        public float Horizontal;
        public float Vertical;

        void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        void Update()
        {
            if (IsMoving)
            {
                _animator.SetBool(_isMovingKey, true);
                
                _animator.SetFloat(_horizontalKey, Horizontal);
                _animator.SetFloat(_verticalKey, Vertical);
            }
            else
            {
                _animator.SetBool(_isMovingKey, false);
            }
        }

        public void Attack()
        {
            _animator.SetTrigger(_attackKey);
        }
    }
}