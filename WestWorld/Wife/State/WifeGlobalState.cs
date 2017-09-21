using System;

namespace WestWorld.FSM
{
    public class WifeGlobalState : State<Wife>
    {
        static WifeGlobalState instance = null;
        private WifeGlobalState() { }

        public static WifeGlobalState Instance()
        {
            if (instance == null)
            {
                instance = new WifeGlobalState();
            }
            return instance;
        }

        public override void Enter(Wife entity)
        {
        }

        public override void Execute(Wife entity)
        {
        }

        public override void Exit(Wife entity)
        {
        }

        public override bool OnMessage(Wife wife, Telegram msg)
        {
            switch(msg.type)
            {
                case MessageType.HiHoneyImHome:
                    Console.WriteLine("\nMessage handled by " + wife.id + " at time: " + DateTime.Now);
                    Console.WriteLine(wife.id + ": Hi honey, let me make you some of mah fine country stew");
                    wife.ChangeState(CookStew.Instance());
                break;
            }
            return true;
        }
    }
}
