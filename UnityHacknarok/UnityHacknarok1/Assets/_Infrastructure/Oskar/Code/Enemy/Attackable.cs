using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Enemy
{
    public class Attackable : MonoBehaviour
    {
        public Action Hit;
        
        public void GotHit()
        {
            Hit?.Invoke();
        }
    }
}
