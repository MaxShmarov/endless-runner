using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace EndlessRunner.Blocks
{
    public class BlocksGenerator
    {
        private BlockPool _pool;
        private int _minimumSize;
        private List<Block> _way = new List<Block>();

        public BlocksGenerator(BlockPool pool, int minimumSize)
        {
            _pool = pool;
            _minimumSize = minimumSize;
        }

        public void Generate()
        {
            while (_way.Count < _minimumSize)
            {
                var block = _pool.Get();
                block.SetActive(true);
                block.Destroyed += OnBlockDestroyed;

                if (_way.Count > 0)
                {
                    MakeNeighbor(_way[_way.Count - 1], block);
                }

                _way.Add(block);
            }
        }

        private void OnBlockDestroyed(Block block)
        {
            block.Destroyed -= OnBlockDestroyed;

            _way.Remove(block);
            _pool.Put(block);

            Generate();
        }

        private void MakeNeighbor(Block block1, Block block2)
        {
            block2.transform.position = new Vector3(block1.transform.position.x, block1.transform.position.y, block1.transform.position.z + block1.Size);
        }
    }
}