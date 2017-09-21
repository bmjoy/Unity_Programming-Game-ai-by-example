using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWorld.FSM;

namespace WestWorld
{
    public class Wife : BaseEntity
    {
        bool cook = false;
        StateMachine<Wife> stateMachine;

        public Wife(int id) : base(id)
        {
            this.stateMachine = new StateMachine<Wife>(this);
            this.stateMachine.SetCurrentState(DoHouseWork.Instance());
            this.stateMachine.SetGlobalState(WifeGlobalState.Instance());
        }

        public bool Cooking()
        {
            return this.cook;
        }

        public void SetCooking(bool val)
        {
            this.cook = val;
        }

        public void ChangeState(State<Wife> state)
        {
            this.stateMachine.ChangeState(state);
        }

        public StateMachine<Wife> GetFMS()
        {
            return this.stateMachine;
        }

        public override bool HandleMessage(Telegram msg)
        {
            return this.stateMachine.HandleMessage(msg);
        }

        public override void Update()
        {
        }
    }
}
