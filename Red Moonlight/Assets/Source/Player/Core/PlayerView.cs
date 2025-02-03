using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        public float Speed { get; private set; }
        private Rigidbody2D _rb;

        public void Construct(float speed)
        {
            Speed = speed;
        }
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        public void Move(float speed, Vector2 direction)
        {
            _rb.velocity = new Vector2(direction.x * speed, _rb.velocity.y);
        }
    }
}