using UnityEngine;

namespace Assets
{
    public class PlayerBehaviour : MonoBehaviour {
        private PlayerState _state;

        public float JumpHeight;

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

            rigidbody2D.AddForce(new Vector2(movement*10, 0));            
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
