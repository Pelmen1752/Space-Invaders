using System;
using System.Threading;

namespace Space_Invaders
{

    internal class PlayerControler
    {
        public event MyEvent ButtonLeft;
        public event MyEvent ButtonRight;
        public event MyEvent ButtonSpace;
        public event MyEvent PressPause;
        public event MyEvent PressExit;
        public event MyEvent PressRestart;
        public bool IsNotEnd { get; set; }

        public void ButtonClick()
        {
            IsNotEnd = true;
            while (IsNotEnd)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key.Equals(ConsoleKey.LeftArrow))
                {
                    ButtonLeft?.Invoke();

                }
                if (key.Key.Equals(ConsoleKey.RightArrow))
                {
                    ButtonRight?.Invoke();

                }
                if (key.Key.Equals(ConsoleKey.Spacebar))
                {
                    ButtonSpace?.Invoke();
                }
                if (key.Key.Equals(ConsoleKey.P))
                {
                    PressPause?.Invoke();

                }
                if (key.Key.Equals(ConsoleKey.Escape))
                {
                    Thread.CurrentThread.IsBackground = true;
                    PressExit?.Invoke();
                }
                if (key.Key.Equals(ConsoleKey.Enter))
                {
                    PressRestart?.Invoke();

                }
            }
        }
    }
}
