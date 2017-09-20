using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWorld.FSM
{
    public class GoHomeAndSleepTilRes : State<Miner>
    {
        static GoHomeAndSleepTilRes instance = null;
        private GoHomeAndSleepTilRes()
        {
        }

        public static GoHomeAndSleepTilRes Instance()
        {
            if (instance == null)
            {
                instance = new GoHomeAndSleepTilRes();
            }
            return instance;
        }

        public override void Enter(Miner miner)
        {
            MessageDispatcher dispatcher = MessageDispatcher.Instance();
            dispatcher.DispatchMessage(0, 1, 2, MessageType.HiHoneyImHome, null);

            Console.WriteLine("Woohoo! Rich enough for now. Back home to mah li'l day");
            Console.WriteLine("Wakin' home");
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine("What a God-darn fantastic nap! Time to find more gold");
        }

        public override void Execute(Miner miner)
        {
            miner.Sleep();
            Console.WriteLine("ZZZZZ");
            Console.WriteLine("ZZZZZ");
            Console.WriteLine("ZZZZZ");
            miner.ChangeState(EnterMineAndDigState.Instance());
        }

        public override bool OnMessage(Miner entity, Telegram telegram)
        {
            throw new NotImplementedException();
        }
    }
}
