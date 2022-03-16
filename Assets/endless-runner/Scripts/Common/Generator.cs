using EndlessRunner.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunner.Common
{
    public abstract class Generator<T> where T : MonoBehaviour, IActivable, IDestroyable<T>
    {
        protected Pool<T> _pool;
        protected int _minimalCount;
        protected List<T> _activeItems;

        public Generator(Pool<T> pool, int minimalCount)
        {
            _activeItems = new List<T>();
            _pool = pool;

            SetMinimalCount(minimalCount);
        }

        protected abstract void SetItemPosition(T item, int index);

        public void SetMinimalCount(int minimalCount)
        {
            _minimalCount = minimalCount;
        }

        public void Generate()
        {
            while (_activeItems.Count < _minimalCount)
            {
                var item = _pool.Get();
                item.SetActive(true);
                item.Destroyed += OnDestroyed;

                _activeItems.Add(item);

                SetItemPosition(item, _activeItems.IndexOf(item));
            }
        }

        private void OnDestroyed(T item)
        {
            item.Destroyed -= OnDestroyed;

            _activeItems.Remove(item);
            _pool.Put(item);

            Generate();
        }
    }
}