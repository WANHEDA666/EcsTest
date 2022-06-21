namespace Interfaces
{
    public interface IDoorsView
    {
        Door[] Doors { get; }
        void MoveDoor(int doorId);
    }
}