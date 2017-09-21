using System;
using System.Collections.Generic;

namespace WestWorld.FSM
{
    public class CookStew : State<Wife>
    {
        public float cookTime = 3f;
        static CookStew instance = null;
        private CookStew() { }

        public static CookStew Instance()
        {
            if (instance == null)
            {
                instance = new CookStew();
            }
            return instance;
        }
        public override void Enter(Wife entity)
        {
            if (!entity.Cooking())
            {
                Console.WriteLine(entity.id + ": Puttin' the stew in the oven");

                //send message to herself so that she know when to take the stew
                Console.WriteLine("Message send by " + entity.id + " at time : " + DateTime.Now);
                MessageDispatcher.Instance().DispatchMessage(cookTime, entity.id, entity.id, MessageType.StewReady, null);
            }
            entity.SetCooking(true);

        }

        public override void Execute(Wife entity)
        {
        }

        public override void Exit(Wife entity)
        {
        }

        public override bool OnMessage(Wife entity, Telegram msg)
        {
            switch(msg.type)
            {
                case MessageType.StewReady:
                    Console.WriteLine("Message received by " + entity.id + " at time " + DateTime.Now);
                    Console.WriteLine(entity.id + ": Stew ready! Let's eat");

                    MessageDispatcher.Instance().DispatchMessage(0f, entity.id, 1, MessageType.StewReady, null);

                    entity.SetCooking(false);
                    entity.ChangeState(DoHouseWork.Instance());
                    return true;
            }
            return false;
        }
    }
}
