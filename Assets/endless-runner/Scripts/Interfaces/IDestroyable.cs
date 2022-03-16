using System;

namespace EndlessRunner.Interfaces
{
    public interface IDestroyable
    {
        public void DestroyThis();
    }

    public interface IDestroyable<T> : IDestroyable
    {
        public event Action<T> Destroyed;
    }
}