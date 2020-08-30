using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Interactions
{
    public class InteractionRequireItem : Interaction
    {
        [SerializeField] [Range(0,100)] private int _requiredItemID;

        public override void Interact()
        {
            
        }
    }
}