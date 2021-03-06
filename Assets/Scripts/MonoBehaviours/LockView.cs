using Interfaces;
using UnityEngine;

namespace MonoBehaviours
{
    [System.Serializable]
    public class LockView : MonoBehaviour, ILockView
    {
        [SerializeField] private DoorView door;
        [SerializeField] private Transform button;
        public IDoorView DoorView => door;
        public SimpleVector2 Button => new SimpleVector2(button.position.x, button.position.z);
    }
}