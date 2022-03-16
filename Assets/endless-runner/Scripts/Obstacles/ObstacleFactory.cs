using EndlessRunner.Common;
using UnityEngine;

namespace EndlessRunner.Obstacles
{
    [CreateAssetMenu(fileName = "ObstacleFactory", menuName = "New obstacle factory")]
    public class ObstacleFactory : Factory<Obstacle>
    {
    }
}