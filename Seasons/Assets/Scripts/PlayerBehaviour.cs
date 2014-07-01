using System.Linq;
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
        private bool _isGrounded;

        private InputBehaviour _inputBehaviour;
        public Transform GroundDetector;
        public LayerMask GroundDetectorLayerMask;

        // Use this for initialization
        void Start ()
        {
            _inputBehaviour = GetComponent<InputBehaviour>();
            _inputBehaviour.enabled = false;
            _anim = GetComponent<Animator>();
            _facingRight = true;
            _isGrounded = true;
        }

        void FixedUpdate()
        {
            //Determine if grounded
            _isGrounded = Physics2D.OverlapCircle(GroundDetector.position, 0.2f, GroundDetectorLayerMask.value);

            Debug.Log("Pos " + GroundDetector.transform.position);

            Debug.Log("Grounded" + _isGrounded);

            //Update animator
            _anim.SetFloat("horizSpeed", Math.Abs(rigidbody2D.velocity.x));
            _anim.SetFloat("verticalSpeed", rigidbody2D.velocity.y);
            _anim.SetBool("isGrounded", _isGrounded);
        }

        // Update is called once per frame
        void Update () {
	
        }

        public void Jump()
        {
            if (_isGrounded)
            {
                rigidbody2D.AddForce(Vector2.up*JumpHeight);
                _isGrounded = false;
            }
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
