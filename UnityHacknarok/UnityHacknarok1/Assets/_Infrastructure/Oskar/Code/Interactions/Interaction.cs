using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Interactions
{
    public class Interaction : MonoBehaviour
    {
        public virtual void Interact() => print("Interacting");
        public virtual void LeftInteractionZone() => print("Left interaction zone");
    }
}