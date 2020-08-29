using System.Collections;
using System.Collections.Generic;
using Infrastructure.Player;
using UnityEngine;

namespace Infrastructure.Interactions
{
    [RequireComponent(typeof(Collider2D))]
    public class FSMInteractionController : MonoBehaviour
    {
        [SerializeField] private PlayMakerFSM _fsm;
        [SerializeField] private string _eventName = "Interact";
        
        private PlayerInput _playerInput;

        void Awake()
        {
            _playerInput = PlayerInput.Instance;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!IsPlayer(other)) return;

            _playerInput.InteractionKeyPressed += Interact;
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if(!IsPlayer(other)) return;

            _playerInput.InteractionKeyPressed -= Interact;
        }

        bool IsPlayer(Collider2D other)
        {
            return other.gameObject.GetComponent<PlayerControler>();
        }
        
        void Interact()
        {
            _fsm.SendEvent(_eventName);
        }
    }
}