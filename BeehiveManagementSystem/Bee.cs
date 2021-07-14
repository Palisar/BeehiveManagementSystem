using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class Bee
    {
        public string Job
        {
            get;
            private set;
        }
        public Bee(string job){ Job = job;}

        public virtual float CostPerShift 
        {
            get;
            
        }

        public void WorkNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift))
            {
                DoJob();
            }
        }
        protected virtual void DoJob()
        {
            Console.WriteLine("This should never get called");
        }
        


    }
}
