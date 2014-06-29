using UnityEngine;
using System;

namespace Assets
{
    public class PlayerBehaviour : MonoBehaviour {
        private PlayerState _state;

		//Public properties
        public float JumpHeight;

		public float MaxMovementVelocity;

        // Use this for initialization
        void Start ()
        {
            _state = PlayerState.Falling;
        }

        void FixedUpdate()
        {
            if (_state == PlayerState.Jumping && rigidbody2D.velocity.y < 0)
            {
                _state = PlayerState.Falling;
            }
        }

        // Update is called once per frame
        void Update () {
	
        }

        public void Jump()
        {
            //We can only jump if we are OnGround
            if (_state == PlayerState.OnGround)
            {
                rigidbody2D.AddForce(Vector2.up*JumpHeight);
                _state = PlayerState.Jumping;
            }
        }

        public void Move(float movement)
        {
			//Cutoff to max movement speed
			if (Math.Abs(rigidbody2D.velocity.x) < MaxMovementVelocity) {

            	rigidbody2D.AddForce(new Vector2(movement*10, 0));

			}
			Debug.Log ("Movement - " + rigidbody2D.velocity.x);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            //We've collided with a platform, we can check the first contact point's normal to see if we landed on it
            if (collision.gameObject.CompareTag("Platform"))
            {
                if (collision.contacts[0].normal == Vector2.up)
                {
                    _state = PlayerState.OnGround;
                }
            }
        }
    }

    public enum PlayerState
    {
        OnGround,
        Falling,
        Jumping
    }
}
