namespace MazeGameBase
{
    public interface IRenderer
    {
        void Prepare();
        void Render(string[] maze);
        void Clear();
    }
}