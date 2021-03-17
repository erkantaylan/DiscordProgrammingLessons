namespace MazeGameBase
{
    public class GameController
    {
        private readonly IInput input;
        private readonly string[] maze;
        private readonly string playerPixel;
        private readonly int playerPosition;
        private readonly IRenderer renderer;
        private readonly string wallPixel;
        private bool isGameEnded;
        private PlayerController playerController;

        public GameController(
            string playerPixel,
            int playerStartPosition,
            string[] maze,
            string wallPixel,
            IInput input,
            IRenderer renderer)
        {
            this.playerPixel = playerPixel;
            playerPosition = playerStartPosition;
            this.maze = maze;
            this.wallPixel = wallPixel;
            this.input = input;
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
            maze[playerPosition] = playerPixel;
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