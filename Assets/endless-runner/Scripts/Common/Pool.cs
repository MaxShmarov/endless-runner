using EndlessRunner.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunner.Common
{
    public class Pool<T> where T : MonoBehaviour, IActivable
    {
        private Factory<T> _factory;
        private Queue<T> _queue;


        public Pool(Factory<T> factory)
        {
            _factory = factory;
            _queue = new Queue<T>();
        }

        public void Initialize(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
            {
                Put(_factory.Create());
            }
        }

        public T Get()
        {
            if (_queue.Count > 0)
            {
                return _queue.Dequeue();
            }
            else
            {
                return _factory.Create();
            }
        }

        public void Put(T block)
        {
            block.SetActive(false);

            _queue.Enqueue(block);
        }
    }
}