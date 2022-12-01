using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode1
{
    public class Elf
    {
        public int employeeNumber { get; set; }
        public List<FoodItem> Provisions { get; set;}
        
        public int GetProvisionCalorieCount()
        {
            if (Provisions == null || Provisions.Count == 0)
                return 0;

            var calorieCount = 0;

            foreach (var item in Provisions)
            {
                calorieCount += item.calories;
            }

            return calorieCount;
        }
    }

    public class FoodItem
    {
       public int calories { get; set; }
    }
}
