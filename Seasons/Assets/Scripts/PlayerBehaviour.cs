using UnityEngine;
using System;

namespace Assets
{
    public class PlayerBehaviour : MonoBehaviour {

		//Public properties
        public float JumpHeight;

		public float MaxMovementVelocity;


        private Animator _anim;
        private bool _facingRight;

        private InputBehaviour _inputBehaviour;

        // Use this for initialization
        void Start ()
        {
            _inputBehaviour = GetComponent<InputBehaviour>();
            _inputBehaviour.enabled = false;
            _anim = GetComponent<Animator>();
            _facingRight = true;
        }

        void FixedUpdate()
        {
            //Update animator
            _anim.SetFloat("horizSpeed", Math.Abs(rigidbody2D.velocity.x));
        }

        // Update is called once per frame
        void Update () {
	
        }

        public void Jump()
        {
           
        }

        public void EnableInput()
        {
            _inputBehaviour.enabled = true;
        }

        public void Move(float movement)
        {
			rigidbody2D.velocity = new Vector2(movement * MaxMovementVelocity, rigidbody2D.velocity.y);

            //Flip if necessary
            if (movement > 0 && !_facingRight || movement < 0 && _facingRight)
                Flip();

        }

        private void Flip()
        {
            var localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;

            _facingRight = !_facingRight;
        }
    }

}
