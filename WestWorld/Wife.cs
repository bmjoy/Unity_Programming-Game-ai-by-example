using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWorld
{
    public class Wife : BaseEntity
    {
        StateMachine<Miner> stateMachine;

        public Wife(int id) : base(id)
        {
        }
    }
}
