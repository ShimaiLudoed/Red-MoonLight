using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        public float Speed { get; private set; }
        private Rigidbody2D _rb;
        private Animator _animator;
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>(); 
        }
        public void Construct(float speed)
        {
            Speed = speed;
        }
        public void Move(float speed, Vector2 direction)
        {
            _rb.velocity = new Vector2(direction.x * speed, _rb.velocity.y);

            if (direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); 
            }

            _animator.SetBool("isWalking", direction.x != 0);
        }
    }
}