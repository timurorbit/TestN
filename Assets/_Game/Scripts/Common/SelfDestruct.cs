using UnityEngine;

namespace MageDefence
{
    public class SelfDestruct : MonoBehaviour
    {
        private float _lifetime = 5f;

        public void Initialize(float lifetime)
        {
            _lifetime = lifetime;
            Destroy(gameObject, _lifetime);
        }
    }  
}
