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
            Console.WriteLine("Woohoo! Rich enough for now. Back home to mah li'l day");
            Console.WriteLine("Wakin' home");

            Console.WriteLine("Message send by " + miner.id + " at time : " + DateTime.Now);
            dispatcher.DispatchMessage(0, 1, 2, MessageType.HiHoneyImHome, null);
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine("What a God-darn fantastic nap! Time to find more gold");
        }

        public override void Execute(Miner miner)
        {
            miner.Sleep();
        }

        public override bool OnMessage(Miner miner, Telegram msg)
        {
            switch(msg.type)
            {
                case MessageType.StewReady:
                    Console.WriteLine("Message received by " + miner.id + " at time: " + DateTime.Now);
                    Console.WriteLine(miner.id + ": Okay hum, ahm a-comin'!");

                    miner.ChangeState(EatStew.Instance());
                    return true;
            }
            return false;
        }
    }
}
