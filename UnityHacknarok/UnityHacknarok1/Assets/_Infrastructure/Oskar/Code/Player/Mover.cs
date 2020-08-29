using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] [Range(0.1f, 100)] private float _speed;
        [SerializeField] [Range(0.1f, 1)] private float _stopHardness = 0.1f;
        
        private Rigidbody2D _rb;

        private Vector2 _moveVector;
        
        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Move(float horizontal, float vertical)
        {
            GetMoveVectorFromInput(horizontal, vertical);
            MoveRigidbody();
        }

        private void GetMoveVectorFromInput(float horizontal, float vertical)
        {
            _moveVector = new Vector2(horizontal, vertical).normalized;
        }

        private void MoveRigidbody()
        {
            if(_moveVector.magnitude <= _stopHardness)
                _rb.velocity = Vector2.zero;
            
            _rb.MovePosition(_rb.position + _moveVector * _speed * Time.fixedDeltaTime);
        }
    }
}