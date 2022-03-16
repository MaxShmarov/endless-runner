using EndlessRunner.GameLogic;
using UnityEngine;

namespace EndlessRunner.Blocks
{
    public class BlocksDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var block = other.transform.parent.GetComponent<DestroyTrigger>();

            if (block != null)
            {
                block.Destroyable.DestroyThis();
            }
        }
    }
}