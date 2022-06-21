using Components;

namespace Interfaces
{
    public interface IPlayerView
    {
        void Move(ref PlayerComponent playerComponent, InputComponent inputComponent);
    }
}