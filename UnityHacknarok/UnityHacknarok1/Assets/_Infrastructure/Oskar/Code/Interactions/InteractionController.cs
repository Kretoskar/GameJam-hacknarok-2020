using System.Collections;
using System.Collections.Generic;
using Infrastructure.Player;
using UnityEngine;

namespace Infrastructure.Interactions
{
    public class InteractionController : MonoBehaviour
    {
        [SerializeField] private Interaction _interaction;
        
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
            _interaction.Interact();
        }
    }
}