using Interfaces;
using UnityEngine;

namespace MonoBehaviours
{
    public class DoorView : MonoBehaviour, IDoorView
    {
        [SerializeField] private Transform door;
        public SimpleVector2 Door
        {
            get
            {
                var localPosition = door.localPosition;
                return new SimpleVector2(localPosition.x, localPosition.z);
            }
            set => door.localPosition = new Vector3(value.x, 0, value.y);
        }
    }
}