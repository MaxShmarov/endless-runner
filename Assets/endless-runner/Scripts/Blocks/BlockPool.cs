using System.Collections.Generic;

namespace EndlessRunner.Blocks
{
    public class BlockPool
    {
        private BlockFactory _blockFactory;
        private Queue<Block> _blocks;

        public BlockPool(BlockFactory blockFactory)
        {
            _blockFactory = blockFactory;
            _blocks = new Queue<Block>();
        }

        public void Initialize(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
            {
                Put(_blockFactory.Create());
            }
        }

        public Block Get()
        {
            if (_blocks.Count > 0)
            {
                return _blocks.Dequeue();
            }
            else
            {
                return _blockFactory.Create();
            }
        }

        public void Put(Block block)
        {
            block.SetActive(false);

            _blocks.Enqueue(block);
        }
    }
}