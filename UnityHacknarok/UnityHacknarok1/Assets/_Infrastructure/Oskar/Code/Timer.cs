using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float _maxTime = 120;
        [SerializeField] private Image _fillImage;

        private float _currTime;

        void Start()
        {
            _currTime = _maxTime;
        }
        
        void Update()
        {
            _currTime -= Time.deltaTime;

            UpdateUI();
        }

        public void GetDamage(int damage)
        {
            _currTime -= damage;
        }
        
        void UpdateUI()
        {
            _fillImage.fillAmount = _currTime / _maxTime;
        }
    }
}