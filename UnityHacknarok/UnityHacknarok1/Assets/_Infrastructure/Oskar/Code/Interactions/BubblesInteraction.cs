using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using Infrastructure.Interactions;
using Infrastructure.LevelManagement;
using UnityEngine;

namespace Infrastructure.Interactions
{
    public class BubblesInteraction : Interaction
    {
        [SerializeField] private int _scoreAdd = 20;
        [SerializeField] private int _timerAdd = 5;

        [SerializeField] private float _interactionTime = 1;

        [SerializeField] private GameObject _bubblesGameObject;

        public override void Interact()
        {
            StartCoroutine(InteractCoroutine());
        }

        private IEnumerator InteractCoroutine()
        {
            PlayerInput.Instance.BlockInputCompletely = true;
            _bubblesGameObject.SetActive(true);
            
            GetComponent<PlayMakerFSM>().SendEvent("Clean");
            
            yield return new WaitForSeconds(_interactionTime);
            
            Timer.Instance.AddTime(_timerAdd);
            ScoreManager.Instance.AddScore(_scoreAdd);

            
            _bubblesGameObject.SetActive(false);
            PlayerInput.Instance.BlockInputCompletely = false;
        }
    }
}
