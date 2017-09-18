namespace WestWorld
{
    public abstract class State<T>
    {
        public abstract void Execute(T entity);
        public abstract void Enter(T entity);
        public abstract void Exit(T entity);

        public abstract bool OnMessage(T entity, Telegram telegram);
    }
}
