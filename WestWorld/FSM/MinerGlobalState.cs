using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWorld.FSM
{
    public class MinerGlobalState : State<Miner>
    {
        static MinerGlobalState instance = null;

        private MinerGlobalState()
        {
        }

        public static MinerGlobalState Instance()
        {
            if (instance == null)
            {
                instance = new MinerGlobalState();
            }
            return instance;
        }

        public override void Enter(Miner miner)
        {

        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine("Ah'm leavin' the gold mine with mah pockets full o' sweet gold");
        }

        public override void Execute(Miner miner)
        {
        }

        public override bool OnMessage(Miner entity, Telegram telegram)
        {
            throw new NotImplementedException();
        }
    }
}
