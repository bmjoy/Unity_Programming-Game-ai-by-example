using System;
using System.Collections.Generic;

namespace WestWorld.FSM
{
    class CookStew : State<Wife>
    {
        public override void Enter(Wife entity)
        {
        }

        public override void Execute(Wife entity)
        {
        }

        public override void Exit(Wife entity)
        {
        }

        public override bool OnMessage(Wife entity, Telegram telegram)
        {
            throw new NotImplementedException();
        }
    }
}
