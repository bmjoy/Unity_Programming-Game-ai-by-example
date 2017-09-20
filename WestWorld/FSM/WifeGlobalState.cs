using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWorld.FSM
{
    class WifeGlobalState : State<Wife>
    {
        public override void Enter(Wife entity)
        {
            throw new NotImplementedException();
        }

        public override void Execute(Wife entity)
        {
            throw new NotImplementedException();
        }

        public override void Exit(Wife entity)
        {
            throw new NotImplementedException();
        }

        public override bool OnMessage(Wife entity, Telegram msg)
        {
            if (msg.receiver == entity.id)
            {
                switch (msg.type)
                {
                    case MessageType.HiHoneyImHome:
                        Console.WriteLine("Welcome back, my honey. Let me make you some of mah fine country stew");
                        break;
                }
                return true;
            }
            return false;
        }
    }
}
