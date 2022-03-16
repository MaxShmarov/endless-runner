using EndlessRunner.Interfaces;
using System;
using UnityEngine;

namespace EndlessRunner.Obstacles
{
    public class Obstacle : MonoBehaviour, IActivable, IDestroyable<Obstacle>
    {
        public event Action<Obstacle> Destroyed;
        public ObstacleType Type { get; private set; } = ObstacleType.None;

        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Color _goodColor;
        [SerializeField] private Color _badColor;

        public void DestroyThis()
        {
            Destroyed?.Invoke(this);
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);

            if (active)
            {
                Initialize();
            }
        }

        private void Initialize()
        {
            if (UnityEngine.Random.value < 0.5)
            {
                Type = ObstacleType.Good;
            }
            else
            {
                Type = ObstacleType.Bad;
            }

            ChangeColor();
        }

        private void ChangeColor()
        {
            Color color = Color.white;

            switch (Type)
            {
                case ObstacleType.Good:
                    color = _goodColor;
                    break;
                case ObstacleType.Bad:
                    color = _badColor;
                    break;
            }

            _meshRenderer.material.color = color;
        }
    }
}