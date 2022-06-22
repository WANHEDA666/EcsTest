using Interfaces;
using UnityEngine;

namespace MonoBehaviours
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        public SimpleVector2 Position
        {
            get => new SimpleVector2();
            set => transform.position = new Vector3(value.x, 0, value.y);
        }

        public SimpleVector2 Target
        {
            set => transform.LookAt(new Vector3(value.x, 0, value.y));
        }
    }
}