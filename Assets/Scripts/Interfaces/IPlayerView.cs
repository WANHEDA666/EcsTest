namespace Interfaces
{
    public interface IPlayerView
    {
        SimpleVector2 Position { get; set; }
        SimpleVector2 Target { set; }
    }
}