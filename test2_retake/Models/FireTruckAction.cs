using System;
using System.Collections.Generic;

namespace test2_retake
{
    public partial class FireTruckAction
    {
        public int ActionIdAction { get; set; }
        public int FireTruckIdFireTruck { get; set; }
        public int IdFireTruckAction { get; set; }
        public DateTime AssignmentDate { get; set; }

        public virtual Action ActionIdActionNavigation { get; set; } = null!;
        public virtual FireTruck FireTruckIdFireTruckNavigation { get; set; } = null!;
    }
}
