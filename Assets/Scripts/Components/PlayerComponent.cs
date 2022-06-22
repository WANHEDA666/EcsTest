using Interfaces;

namespace Components
{
    public struct PlayerComponent
    {
        public IPlayerView PlayerView;
        private SimpleVector2 position;
        public SimpleVector2 Position
        {
            get => position;
            set
            {
                position = value;
                PlayerView.Position = new SimpleVector2(position.x, position.y);
            }
        }
    }
}