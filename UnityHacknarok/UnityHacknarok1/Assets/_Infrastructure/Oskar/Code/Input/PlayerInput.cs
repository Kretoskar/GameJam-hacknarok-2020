using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure
{
    public class PlayerInput : MonoBehaviour
    {
        #region Singleton

        private static PlayerInput _instance;

        public static PlayerInput Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<PlayerInput>();
                    if (_instance == null)
                    {
                        GameObject container = new GameObject("PlayerInput");
                        _instance = container.AddComponent<PlayerInput>();
                    }
                }

                return _instance;
            }
        }
        

        #endregion
        
        [SerializeField] private string _interactionKey;
        [SerializeField] private string _attackKey;
        
        private const string HORIZONTAL_AXIS_KEY = "Horizontal";
        private const string VARTICAL_AXIS_KEY = "Vertical";
        
        private Camera _mainCamera;
        
        public Action InteractionKeyPressed;

        public Action AttackKeyPressed;
        
        public float HorizontalAxis { get; private set; }

        public float VerticalAxis { get; private set; }

        public Vector2 DirectionFromPlayerToMouse => (MousePositionInWorld - (Vector2) transform.position).normalized;
        
        public Vector2 MousePositionInWorld => _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        void Awake()
        {
            _mainCamera = Camera.main;
        }
        
        private void Update()
        {
            HorizontalAxis = Input.GetAxisRaw(HORIZONTAL_AXIS_KEY);
            VerticalAxis = Input.GetAxisRaw(VARTICAL_AXIS_KEY);

            if (Input.GetButtonDown(_attackKey))
            {
                AttackKeyPressed?.Invoke();
            }
            
            if (Input.GetButtonDown(_interactionKey))
            {
                InteractionKeyPressed?.Invoke();
            }
        }
    }
}