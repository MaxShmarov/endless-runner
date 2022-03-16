using System;
using UnityEngine;

namespace EndlessRunner.Blocks
{
    public class Block : MonoBehaviour
    {
        public event Action<Block> Destroyed;
        public float Size => _size;

        [SerializeField] private float _size;

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        [ContextMenu("destroy")]
        public void DestroyThis()
        {
            Destroyed?.Invoke(this);
        }
    }
}