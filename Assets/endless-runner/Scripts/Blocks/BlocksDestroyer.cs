using UnityEngine;

namespace EndlessRunner.Blocks
{
    public class BlocksDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var block = other.transform.parent.GetComponent<Block>();

            if (block != null)
            {
                block.DestroyThis();
            }
        }
    }
}