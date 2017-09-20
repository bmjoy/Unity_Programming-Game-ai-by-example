using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWorld
{
    public class Wife : BaseEntity
    {
        StateMachine<Wife> stateMachine;

        public Wife(int id) : base(id)
        {
            this.stateMachine = new StateMachine<Wife>(this);
            //this.stateMachine.SetCurrentState();
        }

        public override bool HandleMessage(Telegram msg)
        {
           
        }

        public override void Update()
        {
        }
    }
}
