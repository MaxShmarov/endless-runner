using EndlessRunner.Interfaces;
using UnityEngine;

namespace EndlessRunner.Common
{
    public abstract class Factory<T> : ScriptableObject where T : MonoBehaviour, IActivable
    {
        [SerializeField] private T[] _prefabs;

        protected Transform _parent;

        public virtual void Initialize(Transform transform)
        {
            _parent = transform;
        }

        public T Create()
        {
            var go = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], _parent);

            go.SetActive(false);

            return go;
        }
    }
}