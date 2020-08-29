using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using UnityEngine;

namespace Infrastructure.Player
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Mover))]
    public class PlayerControler : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private Mover _mover;
        
        void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _mover = GetComponent<Mover>();
        }
        
        void FixedUpdate()
        { 
            Move();
        }

        void Move()
        {
            _mover.Move(_playerInput.HorizontalAxis, _playerInput.VerticalAxis);
        }
    }
}