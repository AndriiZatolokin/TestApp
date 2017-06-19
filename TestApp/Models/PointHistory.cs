using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class PointHistory
    {
        public Guid Id { get; set; }

        public Guid PointId { get; set; }

        public Double OldLatitude { get; set; }
        public Double OldLongitude { get; set; }
        public Double NewLatitude { get; set; }
        public Double NewLongitude { get; set; }

        public String OldNotes { get; set; }
        public String NewNotes { get; set; }

        public DateTime OldDate { get; set; }
        public DateTime NewDate { get; set; }

        public DateTime ChangedOn { get; set; }
        public PointHistoryType Action { get; set; }


    }

    public enum PointHistoryType
    {
        Create,
        Edit,
        Delete
    }
}
