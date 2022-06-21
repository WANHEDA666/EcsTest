namespace Interfaces
{
    public interface IInputView
    {
        (float XPosition, float ZPosition) GetMouseCoordinates();
    }
}