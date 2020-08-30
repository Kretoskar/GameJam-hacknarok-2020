using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Interactions
{
    public class InteractionRequireItem : Interaction
    {
        [SerializeField] [Range(0,100)] private int _requiredItemID;

        private Inventory _inventory;

        protected bool _hasItem;
        
        private void Start()
        {
            _inventory = Inventory.Instance;
        }
        
        public override void Interact()
        {
            _hasItem = _inventory.GetItemById(_requiredItemID) != null;
        }
    }
}