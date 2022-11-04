using System;
using System.Threading;

namespace Space_Invaders
{
    internal class Engine
    {
        private bool isNotOver;
        private bool isNotPause;
        private Scene scene;
        private Settings settings;

        private Engine()
        {

        }

        private Engine(Settings settings)
        {
            this.settings = settings;
            isNotOver = true;
            isNotPause = true;
            scene = Scene.GetScene(settings);
        }

        public static Engine GetEngine(Settings settings)
        {
            return new Engine(settings);
        }

        public void Run()
        {
            int allienMove = 0;
            int missleMove = 0;
            int allienMissleFrequency = 0;
            do
            {
                while (isNotPause)
                {
                    scene.Clear(settings);
                    scene.Render(settings);
                    if (allienMove == settings.AlienSpeed)
                    {
                        AllienMove();
                        allienMove = 0;
                    }
                    allienMove++;
                    if (allienMissleFrequency == settings.AllienMissileFrequency)
                    {
                        AllienShot();
                        allienMissleFrequency = 0;
                    }
                    allienMissleFrequency++;
                    if (missleMove == settings.MissileSpeed)
                    {
                        MissileMove();
                        for (int i = 0; i < scene.PlayersMissile.Count; i++)
                            for (int j = 0; j < scene.Alliens.Count; j++)
                                if ((scene.PlayersMissile[i].Coordinate.X == scene.Alliens[j].Coordinate.X) && (scene.PlayersMissile[i].Coordinate.Y == scene.Alliens[j].Coordinate.Y))
                                {
                                    scene.PlayersMissile.RemoveAt(i);
                                    scene.Alliens.RemoveAt(j);
                                    Console.Beep(250, 200);
                                    scene.PointsCounter.Points += 100;
                                    scene.PointsCounter.NumberOfDownedAlliens++;
                                    break;
                                }

                        for (int i = 0; i < scene.PlayersMissile.Count; i++)
                            for (int j = 0; j < scene.AllienMissile.Count; j++)
                                if ((scene.PlayersMissile[i].Coordinate.X == scene.AllienMissile[j].Coordinate.X) && (scene.PlayersMissile[i].Coordinate.Y - scene.AllienMissile[j].Coordinate.Y < 2))
                                {
                                    scene.PlayersMissile.RemoveAt(i);
                                    scene.AllienMissile.RemoveAt(j);
                                    Console.Beep(250, 200);
                                    scene.PointsCounter.Points += 10;
                                    break;
                                }
                        AllienMissileMove();

                        missleMove = 0;
                    }
                    missleMove++;
                    Thread.Sleep(settings.GameSpeed);
                }
            } while (isNotOver);
            GameOver();
            scene.ShowPoints();
        }
        public void PlayerMoveLeft()
        {
            if (scene.Player.Coordinate.X > 1)
            {
                scene.Player.Coordinate.X--;
            }
        }

        public void PlayerMoveRight()
        {
            if (scene.Player.Coordinate.X < scene.sceneWhidth-1)
            {
                scene.Player.Coordinate.X++;
            }
        }

        public void PlayerShot()
        {
            PlayersMissileFactory missileFactory = new PlayersMissileFactory(settings);
            scene.PlayersMissile.Add(missileFactory.CreateGameObject(new Coordinate() { X = scene.Player.Coordinate.X, Y = scene.Player.Coordinate.Y - 1 }));
            Console.Beep(1000, 200);
        }

        public void MissileMove()
        {
            for(int i = 0; i < scene.PlayersMissile.Count; i++)
            {
                if (scene.PlayersMissile[i].Coordinate.Y == 1)
                    scene.PlayersMissile.RemoveAt(i);
                else
                {
                    scene.PlayersMissile[i].Coordinate.Y--;                    
                }

            }
        }
        public void AllienShot()
        {
            AllienMissileFactory missileFactory = new AllienMissileFactory(settings);
            int i = new Random().Next(0, scene.Alliens.Count - 1);
            scene.AllienMissile.Add(missileFactory.CreateGameObject(new Coordinate() { X = scene.Alliens[i].Coordinate.X, Y = scene.Alliens[i].Coordinate.Y + 1 }));
            Console.Beep(500, 200);
        }
        public void AllienMissileMove()
        {
            for (int i = 0; i < scene.AllienMissile.Count; i++)
            {
                if (scene.AllienMissile[i].Coordinate.Y == scene.sceneHeight)
                    scene.AllienMissile.RemoveAt(i);
                else
                {
                    scene.AllienMissile[i].Coordinate.Y++;
                    if ((scene.AllienMissile[i].Coordinate.X == scene.Player.Coordinate.X) && (scene.AllienMissile[i].Coordinate.Y == scene.Player.Coordinate.Y))
                        isNotOver = isNotPause = false;
                    for (int j = 0; j < scene.Ground.Count; j++)
                    {
                        if ((scene.AllienMissile[i].Coordinate.X == scene.Ground[j].Coordinate.X) && (scene.AllienMissile[i].Coordinate.Y == scene.Ground[j].Coordinate.Y))
                        {
                            scene.AllienMissile.RemoveAt(i);
                            scene.Ground.RemoveAt(j);
                            Console.Beep(250, 200);
                            scene.PointsCounter.RemainingGroundObjects--;
                            scene.PointsCounter.Points -= 50;
                            break;
                        }
                    }
                }

            }
        }

        public void AllienMove()
        {
            for (int i = 0; i < scene.Alliens.Count; i++)
            {
                scene.Alliens[i].Coordinate.Y++;
                if (scene.Alliens[i].Coordinate.Y == scene.Player.Coordinate.Y)
                {
                    isNotOver = isNotPause = false;
                }
            }
        }

        public void GameOver()
        {
            scene.Clear(settings);
            Console.SetCursorPosition(scene.sceneWhidth - 12, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over!!!");
            Console.ResetColor();
        }

        public void Pause()
        {
            isNotPause = !isNotPause;
            if (!isNotPause)
            {
                Console.SetCursorPosition(scene.sceneWhidth - 5, 0);
                Console.WriteLine("Pause");
            }
        }
        public void Exit()
        {
            isNotOver = isNotPause = false;
        }
    }
}
