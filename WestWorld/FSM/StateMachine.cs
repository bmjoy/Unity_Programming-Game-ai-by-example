using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWorld
{
    public class StateMachine<T>
    {
        T owner;
        State<T> currentState;
        State<T> previousState;
        State<T> globalState;

        public StateMachine(T owner)
        {
            this.owner = owner;
            this.currentState = null;
            this.previousState = null;
            this.globalState = null;
        }

        public void SetCurrentState(State<T> state)
        {
            this.currentState = state;
        }

        public void SetPreviousState(State<T> state)
        {
            this.previousState = state;
        }

        public void SetGlobalState(State<T> state)
        {
            this.globalState = state;
        }

        public void Update()
        {
            if (this.globalState != null) this.globalState.Execute(owner);
            if (this.currentState != null) this.currentState.Execute(owner);
        }

        public bool HandleMessage(Telegram msg)
        {
            //first see if the current state is valid and that it can handle the message
            if(this.currentState != null && this.currentState.OnMessage(this.owner, msg))
            {
                return true;
            }

            //if not, and if a global state has been implemented, send the message to the global state
            if (this.globalState != null && this.globalState.OnMessage(this.owner, msg))
            {
                return true;
            }

            //no one can handle this message
            return false;
        }

        public void ChangeState(State<T> state)
        {
            this.previousState = this.currentState;

            this.currentState.Exit(owner);
            this.currentState = state;
            this.currentState.Enter(owner);
        }

        public void RevertToPreviousState()
        {
            this.ChangeState(this.previousState);
        }
    }

}
