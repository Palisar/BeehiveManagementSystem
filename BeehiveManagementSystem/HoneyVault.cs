using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    static class HoneyVault
    {
        public const float NECTAR_CONVERSION_RATIO = 0.19f;
        public const float LOW_LEVEL_WARNING = 10f;

        public static string Status 
        { 
            get 
            {
                string status = $"{honey:0.0} units of Honey\n{nectar:0,0} units of Nectar";
                string warnings = "";

                if(honey < LOW_LEVEL_WARNING)
                {
                    warnings += "\nLOW HONEY - ADD A MANUFACTURER";

                }
                if (nectar < LOW_LEVEL_WARNING)
                {
                    warnings += "\nLOW NECTAR - ADD A MANUFACTURER";
                }
                return status + warnings;
            }
        }

        private static float honey = 25f;
        private static float nectar = 100f;

        public static void CollectNectar(float amount)
        {
            if (amount > 0f)
            {
                nectar += amount;
            }
        }

        public static void ConvertNectarToHoney(float amount)
        {
            float nectarToConvert = amount;
            if (nectarToConvert > nectar) nectarToConvert = nectar;
            nectar -= nectarToConvert;
            honey += nectarToConvert * NECTAR_CONVERSION_RATIO;
            
            
        }

        public static bool ConsumeHoney(float amount)
        {
            if (amount <= honey )
            {
                honey -= amount;
                return true;
            }
            return false;
            
        }

    }
}
