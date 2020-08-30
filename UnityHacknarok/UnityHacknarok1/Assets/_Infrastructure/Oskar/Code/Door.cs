using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure
{
    public class Door : MonoBehaviour
    {
        private Collider2D _collider;
        
        #region Singleton
        
        private static Door _instance;

        public static Door Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<Door>();
                    if (_instance == null)
                    {
                        GameObject container = new GameObject("Door");
                        _instance = container.AddComponent<Door>();
                    }
                }

                return _instance;
            }
        }
        
        #endregion

        [SerializeField] private string _animatorTriggerName = "Open";
        
        private Animator _animator;

        void Awake()
        {
            _animator = GetComponent<Animator>();
            _collider = GetComponent<Collider2D>();
        }

        public void Open()
        {
            _collider.enabled = true;
            _animator.SetTrigger(_animatorTriggerName);
        }
    }
}