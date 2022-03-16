using EndlessRunner.Interfaces;
using UnityEngine;

namespace EndlessRunner.GameLogic
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