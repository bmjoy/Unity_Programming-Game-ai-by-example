using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWorld.FSM
{
    class VisitBathroom : State<Wife>
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
