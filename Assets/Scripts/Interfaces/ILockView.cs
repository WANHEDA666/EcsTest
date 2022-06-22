namespace Interfaces
{
    public interface ILockView
    {
        IDoorView DoorView { get; } 
        SimpleVector2 Button { get; }
    }
}