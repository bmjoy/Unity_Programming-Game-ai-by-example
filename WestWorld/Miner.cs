using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWorld.FSM;

namespace WestWorld
{
    public class Miner : BaseEntity
    {
        StateMachine<Miner> stateMachine;
        public LocationType location = LocationType.Mine;
        int goldCarried = 0;
        int maxGoldCarried = 3;

        public int moneyInBank = 0;
        int wealthMoney = 6;

        public int thirst = 0;
        int maxThirst = 3;

        public int fatigue = 0;

        public Miner(int id) : base(id)
        {
            this.stateMachine = new StateMachine<Miner>(this);
            this.stateMachine.SetCurrentState(GoHomeAndSleepTilRes.Instance());
            this.stateMachine.SetGlobalState(MinerGlobalState.Instance());
        }

        public void ChangeState(State<Miner> state)
        {
            this.stateMachine.ChangeState(state);
        }

        public StateMachine<Miner> GetFMS()
        {
            return this.stateMachine;
        }

        public override void Update()
        {
            this.thirst++;
            this.stateMachine.Update();
        }

        public override bool HandleMessage(Telegram msg)
        {
            return this.stateMachine.HandleMessage(msg);
        }

        public void ChangeLocation(LocationType location)
        {
            this.location = location;
        }

        public void DigGold()
        {
            this.goldCarried++;
            Console.WriteLine("Pickin'up a nugget");
        }

        public bool IsPocketFull()
        {
            return this.goldCarried == this.maxGoldCarried;
        }

        public void IncreaseFatigue()
        {
            this.fatigue++;
        }

        public bool IsThirst()
        {
            return this.thirst > this.maxThirst;
        }

        public void Deposit()
        {
            this.moneyInBank += this.goldCarried;
            this.goldCarried = 0;
        }

        public bool IsWealthEnough()
        {
            return this.moneyInBank >= this.wealthMoney;
        }

        public void Sleep()
        {
            this.fatigue = 0;
        }

        public void Drink()
        {
            this.thirst = 0;
        }
    }
}
