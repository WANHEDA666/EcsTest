using Interfaces;
using UnityEngine;

namespace MonoBehaviours
{
    public class DoorView : MonoBehaviour, IDoorView
    {
        [SerializeField] private Transform door;
        public Transform Door => door;
    }
}