using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWorld.FSM
{
    public class QuenchThirst : State<Miner>
    {
        static QuenchThirst instance = null;
        private QuenchThirst() { }

        public static QuenchThirst Instance()
        {
            if (instance == null)
            {
                instance = new QuenchThirst();
            }
            return instance;
        }

        public override void Enter(Miner miner)
        {
            Console.WriteLine("Boy, ah sure is thusty! Walkin' to the saloon");
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine("Leavin' the saloon, feelin' good");
        }

        public override void Execute(Miner miner)
        {
            miner.Drink();
            Console.WriteLine("That's mighty fine sippin liquor");
            miner.ChangeState(EnterMineAndDigState.Instance());
        }

        public override bool OnMessage(Miner entity, Telegram telegram)
        {
            return false;
        }
    }

}
