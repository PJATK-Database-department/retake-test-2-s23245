using System;
using System.Collections.Generic;

namespace test2_retake
{
    public partial class Firefighter
    {
        public Firefighter()
        {
            IdActions = new HashSet<Action>();
        }

        public int IdFirefighter { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<Action> IdActions { get; set; }
    }
}
