using System.Threading;

namespace Space_Invaders
{
    internal delegate void MyEvent();
    internal class Program
    {
        static Engine engine;
        static Settings settings;
        static PlayerControler controler;
        static Thread controlerThread;
        static void Main()
        {
            Initialize();
            controlerThread = new Thread(controler.ButtonClick);
            controlerThread.Start();
            engine.Run();
        }

        static void Initialize()
        {
            settings = new Settings();
            engine = Engine.GetEngine(settings);
            controler = new PlayerControler();
            controler.ButtonRight += engine.PlayerMoveRight;
            controler.ButtonLeft += engine.PlayerMoveLeft;
            controler.ButtonSpace += engine.PlayerShot;
            controler.PressPause += engine.Pause;
            controler.PressExit += engine.Exit;
            controler.PressRestart += Restart;
        }

        static void Restart()
        {
            engine.Exit();
            engine = null;
            controler.IsNotEnd = false;
            Main();
        }
    }
}
