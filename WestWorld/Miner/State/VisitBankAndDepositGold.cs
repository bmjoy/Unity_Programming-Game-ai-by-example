using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWorld.FSM
{
    public class VisitBankAndDepositGold : State<Miner>
    {
        static VisitBankAndDepositGold instance = null;
        private VisitBankAndDepositGold() { }

        public static VisitBankAndDepositGold Instance()
        {
            if (instance == null)
            {
                instance = new VisitBankAndDepositGold();
            }
            return instance;
        }

        public override void Enter(Miner miner)
        {
            Console.WriteLine("Goin' to the bank, Yes siree");
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine("Leavin' the bank");
        }

        public override void Execute(Miner miner)
        {
            miner.ChangeLocation(LocationType.Bank);
            miner.Deposit();
            Console.WriteLine("Depositin' gold, Total saving now: " + miner.moneyInBank);

            if (miner.IsWealthEnough())
            {
                miner.ChangeState(GoHomeAndSleepTilRes.Instance());
            }
            else
            {
                miner.ChangeState(EnterMineAndDigState.Instance());
            }
        }

        public override bool OnMessage(Miner entity, Telegram telegram)
        {
            throw new NotImplementedException();
        }
    }
}
