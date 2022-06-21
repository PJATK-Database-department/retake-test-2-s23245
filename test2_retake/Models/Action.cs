using System;
using System.Collections.Generic;

namespace test2_retake
{
    public partial class Action
    {
        public Action()
        {
            FireTruckActions = new HashSet<FireTruckAction>();
            IdFirefighters = new HashSet<Firefighter>();
        }

        public int IdAction { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool NeedSpecialEquipment { get; set; }

        public virtual ICollection<FireTruckAction> FireTruckActions { get; set; }

        public virtual ICollection<Firefighter> IdFirefighters { get; set; }
    }
}
