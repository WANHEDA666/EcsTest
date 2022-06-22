using Interfaces;

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
                LockView.DoorView.Door = new SimpleVector2(doorPosition.x, doorPosition.y);
            }
        }

        public SimpleVector2 ButtonPosition;
    }
}