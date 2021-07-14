using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class Queen:Bee
    {
        public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;
        public const float EGGS_PER_SHIFT = 0.45f;

        public Queen() : base("Queen")
        {
            AssignBee("Egg Care");
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
        }

        private List<Bee> workers = new List<Bee>();
        private float eggs = 0;
        
        private float unassignedWorkers = 3;
        private int EggCarers = 0;
        private int NectarCollectors = 0;
        private int HoneyManufactureres = 0;
        public string StatusReport { get; private set; }
        public override float CostPerShift
        {
            get { return 2.15f; }
        }


        public void AssignBee(string job)
        {
            if (unassignedWorkers >= 1f)
            {
                switch (job)
                {
                    case "Egg Care":
                        unassignedWorkers -= 1;
                        workers.Add(new EggCare(this));
                        EggCarers++;
                        break;
                    case "Nectar Collector":
                        unassignedWorkers -= 1;
                        workers.Add(new NectarCollector());
                        NectarCollectors++;
                        break;
                    case "Honey Manufacturer":
                        unassignedWorkers -= 1;
                        workers.Add(new HoneyManufacturer());
                        HoneyManufactureres++;
                        break;
                }
            }
            
            UpdateStatusReport();
        }
        
        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach (Bee bee in workers)
            {
                bee.WorkNextShift();
            }
            HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * unassignedWorkers);
            UpdateStatusReport();

        }

        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }

        public void UpdateStatusReport()
        {
            StatusReport = $"Vault Report:\n{HoneyVault.Status}\n" +
                $"\nEggCount: {eggs}\nUnassigned Workers: {unassignedWorkers}" +
                $"\n{NectarCollectors} Nectar Collector bees" +
                $"\n{HoneyManufactureres} Honey Manufaturer bees" +
                $"\n{EggCarers} Egg Carer bees" +
                $"\nTOTAL WORKERS: {NectarCollectors+HoneyManufactureres+EggCarers}";
        }
    }

}
