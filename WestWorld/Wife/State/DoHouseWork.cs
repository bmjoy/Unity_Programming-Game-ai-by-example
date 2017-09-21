using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWorld.FSM
{
    public class DoHouseWork : State<Wife>
    {
        static DoHouseWork instance = null;
        private DoHouseWork() { }

        public static DoHouseWork Instance()
        {
            if (instance == null)
            {
                instance = new DoHouseWork();
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

        public override bool OnMessage(Wife entity, Telegram telegram)
        {
            return false;
        }
    }
}
