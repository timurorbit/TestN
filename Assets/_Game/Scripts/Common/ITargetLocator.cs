using UnityEngine;

namespace MageDefence
{
    public interface ITargetLocator
    {
        public Transform GetTarget(Vector3 currentPosition);

        public void RegisterTarget(Transform target);

        public void UnregisterTarget(Transform target);
    }
}