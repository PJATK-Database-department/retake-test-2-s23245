using System;
using System.Collections.Generic;

namespace test2_retake
{
    public partial class FireTruck
    {
        public FireTruck()
        {
            FireTruckActions = new HashSet<FireTruckAction>();
        }

        public int IdFireTruck { get; set; }
        public string OperationalNumber { get; set; } = null!;
        public bool SpecialEquipment { get; set; }

        public virtual ICollection<FireTruckAction> FireTruckActions { get; set; }
    }
}
