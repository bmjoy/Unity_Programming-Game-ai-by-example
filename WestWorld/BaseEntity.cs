namespace WestWorld
{
    public abstract class BaseEntity
    {
        public int id;
        public BaseEntity(int id)
        {
            this.id = id;
        }

        public abstract void Update();

        public abstract bool HandleMessage(Telegram msg);
    }
}
