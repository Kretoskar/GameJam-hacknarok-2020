using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private string _interactionKey;
        
        private const string HORIZONTAL_AXIS_KEY = "Horizontal";
        private const string VARTICAL_AXIS_KEY = "Vertical";

        public Action InteractionKeyPressed;
        
        public float HorizontalAxis { get; private set; }

        public float VerticalAxis { get; private set; }


        private void Update()
        {
            HorizontalAxis = Input.GetAxis(HORIZONTAL_AXIS_KEY);
            VerticalAxis = Input.GetAxis(VARTICAL_AXIS_KEY);

            if (Input.GetButtonDown(_interactionKey))
            {
                print("chuj");
            }
        }
    }
}