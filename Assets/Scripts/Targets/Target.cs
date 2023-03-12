using UnityEngine.Events;
using UnityEngine;

namespace Targets
{
    public class Target : MonoBehaviour, ITarget
    {
        public UnityEvent<int> OnHit;

        private void OnEnable()
        {
            TargetManager.AddTarget(this);
        }

        private void OnDisable()
        {
            TargetManager.RemoveTarget(this);
        }

        public void Hit(int damage)
        {
            OnHit?.Invoke(damage);
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public bool IsAlive()
        {
            return true;
        }
    }
}
