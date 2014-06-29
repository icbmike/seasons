using System;
using UnityEngine;

namespace Assets
{
    public class InputBehaviour : MonoBehaviour {
        private PlayerBehaviour _playerBehaviour;

        // Use this for initialization
        void Start ()
        {
            _playerBehaviour = GetComponent<PlayerBehaviour>();
        }

        void FixedUpdate(){
            //Jumping
            var shouldJump = Input.GetButton("Jump");

            if (shouldJump)
                _playerBehaviour.Jump();

            //Movement
            var movement = Input.GetAxis("horizontal");

            if(Math.Abs(movement) > 0)
                _playerBehaviour.Move(movement);
        }
    }
}
