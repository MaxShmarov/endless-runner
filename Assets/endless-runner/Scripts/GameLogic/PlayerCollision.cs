using EndlessRunner.Interfaces;
using EndlessRunner.Obstacles;
using UnityEngine;

namespace EndlessRunner.GameLogic
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private Player player;

        private void OnTriggerEnter(Collider other)
        {
            var obstacle = other.transform.parent.GetComponent<IObstacle>();

            if (obstacle != null)
            {
                switch (obstacle.Type)
                {
                    case ObstacleType.Bad:
                        player.TakeDamege();
                        break;
                    case ObstacleType.Good:
                        player.IncreaseScore();
                        break;
                }

                obstacle.Collect();
            }
        }
    }
}