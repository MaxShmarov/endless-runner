using UnityEngine;

namespace EndlessRunner.Blocks
{
    [CreateAssetMenu(fileName = "BlockFactory", menuName = "New block factory")]
    public class BlockFactory : ScriptableObject
    {
        [SerializeField] private Block _prefab;

        private Transform _parent = null;

        public void Initialize(Transform parent)
        {
            _parent = parent;
        }

        public Block Create()
        {
            var block = Instantiate(_prefab, _parent);
            block.SetActive(false);

            return block;
        }
    }
}