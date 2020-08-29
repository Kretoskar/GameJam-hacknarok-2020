using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Player
{
    public class Mover : MonoBehaviour
    {
        public void Move(float horizontal, float vertical)
        {
            Vector2 moveVector = new Vector2(horizontal, vertical);

            print(moveVector);
        }
    }

}