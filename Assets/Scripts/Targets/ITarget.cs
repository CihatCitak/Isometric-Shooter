using UnityEngine;

namespace Targets
{
    public interface ITarget
    {
        void Hit(int damage);

        bool IsAlive();

        Transform GetTransform();
    }
}

