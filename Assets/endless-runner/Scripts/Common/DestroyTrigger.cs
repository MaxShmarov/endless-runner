using EndlessRunner.Interfaces;
using UnityEngine;

namespace EndlessRunner.Common
{
    public class DestroyTrigger : MonoBehaviour
    {
        public IDestroyable Destroyable;

        private void Awake()
        {
            Destroyable = GetComponent<IDestroyable>();
        }
    }
}