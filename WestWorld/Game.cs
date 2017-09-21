using System;
using System.Threading;

namespace WestWorld
{
    public class Game
    {
        EntityManager entityMgr = EntityManager.Instance();
        MessageDispatcher dispatcher = MessageDispatcher.Instance();

        public Game()
        {
            Miner miner = new Miner(1);
            entityMgr.RegisterEntity(miner);

            Wife wife = new Wife(2);
            entityMgr.RegisterEntity(wife);
        }

        public void Update()
        {
            bool flag = true;
            while (flag)
            {
                Thread.Sleep(1000);

                //check message
                dispatcher.DispatchDelayedMessages();

                Miner miner = entityMgr.GetEntity(1) as Miner;
                miner.Update();

                Wife wife = entityMgr.GetEntity(2) as Wife;
                wife.Update();
            }
        }

        static void Main()
        {
            Game game = new Game();
            game.Update();

            Console.ReadKey();
        }
    }
}
