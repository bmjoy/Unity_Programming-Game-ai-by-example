using Priority_Queue;

namespace WestWorld
{
    public class Telegram : FastPriorityQueueNode
    {
        public int sender;
        public int receiver;
        public MessageType type;
        public long dispatchTime; //if a delay is necessary, this field is stamped with the time the message should be dispatched
        public Args args;
    }
}
