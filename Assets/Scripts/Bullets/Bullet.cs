using UnityEngine;
using Targets;

namespace Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] Rigidbody rb;

        private int damage = 5;

        private void Start()
        {
            rb.AddForce(transform.forward.normalized * speed);
        }

        public void Hit(ITarget target)
        {
            target.TakeDamage(damage);
        }

        public void SetDamage(int damage)
        {
            this.damage = damage;
        }
    }
}

