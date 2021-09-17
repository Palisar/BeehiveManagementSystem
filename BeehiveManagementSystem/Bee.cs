using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    /// <summary>
    /// The bee class is at the top of our hierarchy which makes it more abstrack
    /// the higher we go in a class hierarchy the more abstract the classes become and the lower we go, the more concrete they are
    /// </summary>
    abstract class Bee : IWorker
    {
        public string Job { get; private set;}
        public Bee(string job){ Job = job;}

        public abstract float CostPerShift { get; }

        public void WorkNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift))
            {
                DoJob();
            }
        }
        protected abstract void DoJob();


    }
}
