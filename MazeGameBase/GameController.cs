namespace MazeGameBase
{
    public class GameController
    {
        private readonly string[,] maze;
        private readonly string playerPixel;
        private readonly int xPlayerPosition;
        private readonly int yPlayerPosition;
        private readonly IRenderer renderer;
        private bool isGameEnded;
        private PlayerController playerController;

        public GameController(
            string playerPixel,
            int xPlayerStartPosition,
            int yPlayerStartPosition,
            string[,] maze,
            IRenderer renderer)
        {
            this.playerPixel = playerPixel;
            this.xPlayerPosition= xPlayerStartPosition;
            this.yPlayerPosition= yPlayerStartPosition;
            this.maze = maze;
            this.renderer = renderer;

            isGameEnded = false;
        }

        public void EndGame()
        {
            isGameEnded = true;
        }


        public void Start(PlayerController controller)
        {
            playerController = controller;
            Awake();
            Ready();

            while (!isGameEnded)
            {
                Render();
                Update();
                Clear();
            }
        }

        private void Awake()
        {
            renderer.Prepare();
        }

        private void Ready()
        {
            maze[yPlayerPosition, xPlayerPosition] = playerPixel;
        }

        private void Clear()
        {
            renderer.Clear();
        }

        private void Update()
        {
            playerController.Update();
        }

        private void Render()
        {
            renderer.Render(maze);
        }
    }
}