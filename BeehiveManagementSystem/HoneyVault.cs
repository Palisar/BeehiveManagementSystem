using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    static class HoneyVault
    {
        private const float NECTAR_CONVERSION_RATIO = .19f;
        private const float LOW_LEVEL_WARNING = 10f;

        private static string statusReport = $"Vault Report:\n{honey} units of Honey\n{nectar} units of Nectar";
        private static string honeyWarning = "\nLOW HONEY - ADD A MANUFACTURER";
        private static string nectarWarning = "\nLOW NECTAR - ADD A MANUFACTURER";


        public static string StatusReport 
        { 
            get 
            {
                if (nectar < LOW_LEVEL_WARNING && honey < LOW_LEVEL_WARNING)
                {
                    return statusReport + honeyWarning + nectarWarning;
                }
                else if (honey < LOW_LEVEL_WARNING)
                {
                    return statusReport + honeyWarning;
                }
                else if (nectar < LOW_LEVEL_WARNING)
                {
                    return statusReport + nectarWarning;
                }
                else
                {
                    return statusReport;
                }
                
                
            }
        }

        private static float honey = 25f;
        private static float nectar = 100f;

        public static void CollectNectar(float amount)
        {
            if (amount > 0)
            {
                nectar += amount;
            }
        }

        public static void ConvertNectarToHoney(float amount)
        {
            if (amount >= nectar)
            {
                nectar -= amount;
                honey += amount * NECTAR_CONVERSION_RATIO;
            }
            else
            {
                honey += nectar * NECTAR_CONVERSION_RATIO;
                nectar = 0f;
            }
            
        }

        public static bool ConsumeHoney(float amount)
        {
            if (amount <= honey )
            {
                honey -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
