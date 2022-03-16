using EndlessRunner.Common;
using UnityEngine;

namespace EndlessRunner.Blocks
{
    public class BlocksGenerator : Generator<Block>
    {
        public BlocksGenerator(Pool<Block> pool, int minimalCount) : base(pool, minimalCount)
        {
        }

        protected override void SetItemPosition(Block item, int index)
        {
            if (_activeItems.Count > 1)
            {
                var previous = _activeItems[index - 1];
                var newPosition = new Vector3(
                    previous.transform.position.x, 
                    previous.transform.position.y,
                    previous.transform.position.z + previous.Size);

                item.transform.position = newPosition;
            }
        }
    }
}