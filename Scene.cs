using System;
using System.Collections.Generic;
using System.Text;

namespace Space_Invaders
{
    internal class Scene
    {
        public GameObject Player { get; set; }
        public List<GameObject> PlayersMissile { get; set; }
        public List<GameObject> Alliens { get; set; }
        public List<GameObject> AllienMissile { get; set; }
        public List<GameObject> Ground { get; set; }
        public PointsCounter PointsCounter { get; set; }
        public int sceneWhidth { get; set; }
        public int sceneHeight { get; set; }
        char[,] screen;
        private Scene()
        {
        }
        private Scene(Settings settings)
        {
            Player = new PlayerFactory(settings).CreateGameObject(new Coordinate() { X = settings.PlayerStartCoordinateX, Y = settings.PlayerStartCoordinateY});
            Alliens = new AllienShipFactory(settings).CreateAllienShips();
            Ground = new GroundFactory(settings).CreateGround();
            PlayersMissile = new List<GameObject>();
            AllienMissile = new List<GameObject>();
            PointsCounter = PointsCounter.GetPointsCounter(settings);
            sceneWhidth = settings.Width+1;
            sceneHeight = settings.Height+1;
            Console.CursorVisible = false;
            Console.SetWindowSize(sceneWhidth, sceneHeight);
        }

        public static Scene GetScene(Settings settings)
        {
            return new Scene(settings);
        }

        public void Render(Settings settings)
        {
            Console.SetCursorPosition(0, 0);
            AddObjectForRendering(Player);
            AddListForRendering(PlayersMissile);
            AddListForRendering(Alliens);
            AddListForRendering(AllienMissile);
            AddListForRendering(Ground);
            StringBuilder stringBuilder = new StringBuilder();
            for (int y = 0; y < settings.GroundStartCoordinateY+settings.GroundRow; y++)
            {
                for (int x = 0; x < sceneWhidth; x++)
                {
                    if (screen[y, x] != 0)
                        stringBuilder.Append(screen[y, x]);
                    else stringBuilder.Append(' ');
                }
                stringBuilder.Append(Environment.NewLine);
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Количество очков: {0}", PointsCounter.Points);
        }

        public void Clear(Settings settings)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int y = 0; y < settings.GroundStartCoordinateY + settings.GroundRow; y++)
            {
                for (int x = 0; x < sceneWhidth; x++)
                {
                    stringBuilder.Append(' ');
                }
                stringBuilder.Append(Environment.NewLine);
            }
            Console.WriteLine(stringBuilder.ToString());
            screen = new char[sceneHeight, sceneWhidth];
        }

        public void AddObjectForRendering(GameObject gameObject)
        {
            if((gameObject.Coordinate.Y < screen.GetLength(0)) && (gameObject.Coordinate.X < screen.GetLength(1)))
            {
                screen[gameObject.Coordinate.Y, gameObject.Coordinate.X] = gameObject.Figure;
            }
        }

        public void AddListForRendering(List<GameObject> gameObjects)
        {
            foreach(GameObject gameObject in gameObjects)
                AddObjectForRendering(gameObject);
        }
        public void ShowPoints()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Количество очков: {0}", PointsCounter.Points);
            Console.WriteLine("Количество сбитых кораблей: {0}", PointsCounter.NumberOfDownedAlliens);
            Console.WriteLine("Количество оставшихся объектов земли: {0}", PointsCounter.RemainingGroundObjects);
        }
    }
}
