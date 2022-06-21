using Interfaces;
using UnityEngine;

namespace MonoBehaviours
{
    public class DoorsView : MonoBehaviour, IDoorsView
    {
        [SerializeField] public Door[] doors;
        public Door[] Doors => doors;

        public void MoveDoor(int doorId)
        {
            doors[doorId].door.transform.localPosition = Vector3.MoveTowards(doors[doorId].door.transform.localPosition, new Vector3(), 0.5f * Time.deltaTime);
        }
    }
}