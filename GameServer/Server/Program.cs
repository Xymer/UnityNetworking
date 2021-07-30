using System;
using System.Threading;
namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Game Server";
            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();
           
            Server.Start(5,26950);          
        }
        private static void MainThread()
        {
            Console.WriteLine($"Main thread started. Running at {Constants.TICKS_PER_SEC} ticks per second.");
            DateTime nextLoop = DateTime.Now;
            while (Server.serverRunning)
            {
                while (nextLoop < DateTime.Now)
                {
                    GameLogic.Update();
                    nextLoop = nextLoop.AddMilliseconds(Constants.MS_PER_TICK);
                    if (nextLoop > DateTime.Now)
                    {
                        Thread.Sleep(nextLoop - DateTime.Now);
                    }
                }
            }
        }
    }
}
