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
        
        [SerializeField]
        private string _interactionKey;
        
        private const string HORIZONTAL_AXIS_KEY = "Horizontal";
        private const string VARTICAL_AXIS_KEY = "Vertical";

        public Action InteractionKeyPressed;
        
        public float HorizontalAxis { get; private set; }

        public float VerticalAxis { get; private set; }


        private void Update()
        {
            HorizontalAxis = Input.GetAxisRaw(HORIZONTAL_AXIS_KEY);
            VerticalAxis = Input.GetAxisRaw(VARTICAL_AXIS_KEY);

            if (Input.GetButtonDown(_interactionKey))
            {
                InteractionKeyPressed?.Invoke();
            }
        }
    }
}