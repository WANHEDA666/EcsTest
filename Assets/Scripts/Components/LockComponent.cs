using Interfaces;
using UnityEngine;

namespace Components
{
    public struct LockComponent
    {
        public ILockView LockView;
        private SimpleVector2 doorPosition;
        public SimpleVector2 DoorPosition
        {
            get => doorPosition;
            set
            {
                doorPosition = value;
                LockView.DoorView.Door.localPosition = new Vector3(doorPosition.x, 0,  doorPosition.y);
            }
        }

        public SimpleVector2 ButtonPosition;
    }
}