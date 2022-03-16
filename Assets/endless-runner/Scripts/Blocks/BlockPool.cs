using EndlessRunner.Common;
using System.Collections.Generic;

namespace EndlessRunner.Blocks
{
    public class BlockPool : Pool<Block>
    {
        public BlockPool(Factory<Block> factory) : base(factory)
        {
        }
    }
}