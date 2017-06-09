using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class Point
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
    }
}
