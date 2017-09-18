using System.Threading;

namespace WestWorld
{
    public class Game
    {
        EntityManager entityMgr;

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
                //miner.Update();
            }
        }

        static void Main()
        {
            Game game = new Game();
            game.Update();
        }
    }
}
