namespace WestWorld.FSM
{
    public class EatStew : State<Miner>
    {
        static EatStew instance = null;

        private EatStew() { }

        public static EatStew Instance()
        {
            if (instance == null)
            {
                instance = new EatStew();
            }
            return instance;
        }

        public override void Enter(Miner entity)
        {
        }

        public override void Execute(Miner entity)
        {
            entity.ChangeState(EnterMineAndDigState.Instance());
        }

        public override void Exit(Miner entity)
        {
        }

        public override bool OnMessage(Miner entity, Telegram telegram)
        {
            return false;
        }
    }
}
