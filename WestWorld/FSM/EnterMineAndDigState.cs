using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWorld.FSM
{
    public class EnterMineAndDigState : State<Miner>
    {
        static EnterMineAndDigState instance = null;

        private EnterMineAndDigState() { }

        public static EnterMineAndDigState Instance()
        {
            if (instance == null)
            {
                instance = new EnterMineAndDigState();
            }
            return instance;
        }

        public override void Enter(Miner miner)
        {
        }

        public override void Exit(Miner miner)
        {

        }

        public override void Execute(Miner miner)
        {
            if (miner.location != LocationType.Mine)
            {
                Console.WriteLine("Walkin' to the gold mine");
                miner.ChangeLocation(LocationType.Mine);
            }

            if (miner.IsPocketFull())
            {
                miner.ChangeState(VisitBankAndDepositGold.Instance());
            }
            else
            {
                miner.DigGold();
                miner.IncreaseFatigue();

                if (miner.IsThirst())
                {
                    miner.ChangeState(QuenchThirst.Instance());
                }
            }
        }

        public override bool OnMessage(Miner entity, Telegram telegram)
        {
            throw new NotImplementedException();
        }
    }
}
