using System;
using Priority_Queue;

namespace WestWorld
{
    public class MessageDispatcher
    {
        //Singleton
        static MessageDispatcher instance = null;
        SimplePriorityQueue<Telegram> priorityQueue = new SimplePriorityQueue<Telegram>();

        public static MessageDispatcher Instance()
        {
            if (instance == null)
            {
                instance = new MessageDispatcher();
            }
            return instance;
        }

        MessageDispatcher() { }

        //Send message
        public void Discharge(BaseEntity receiver, Telegram msg)
        {
            receiver.HandleMessage(msg);
        }

        //In every loop, we will call this function to make sure there are message to send
        public void DispatchDelayedMessages()
        {
            long currentTime = DateTimeOffset.Now.ToUnixTimeSeconds();

            if (priorityQueue.Count > 0)
            {
                while (priorityQueue.Count > 0 && priorityQueue.First.dispatchTime > 0 && priorityQueue.First.dispatchTime < currentTime)
                {
                    Telegram telegram = priorityQueue.Dequeue();
                    BaseEntity receiver = EntityManager.Instance().GetEntity(telegram.sender);
                    Discharge(receiver, telegram);
                }
            }

        }

        //Add message to message center
        public void DispatchMessage(float delay,
                                    int sender,
                                    int receiver,
                                    MessageType msg,
                                    Args args)
        {
            BaseEntity receiverEntity = EntityManager.Instance().GetEntity(receiver);

            Telegram telegram = new Telegram
            {
                sender = sender,
                args = args,
                dispatchTime = 0,
                receiver = receiver,
                type = msg
            };

            //If there's no delay, send this message immediately
            if (delay <= 0.0f)
            {
                Discharge(receiverEntity, telegram);
            }
            else
            {
                //Send the telegram to the recipient
                telegram.dispatchTime = DateTimeOffset.Now.Add(TimeSpan.FromMilliseconds(delay * 1000)).ToUnixTimeSeconds();
                this.priorityQueue.Enqueue(telegram, telegram.dispatchTime);
            }

        }
    }
}
