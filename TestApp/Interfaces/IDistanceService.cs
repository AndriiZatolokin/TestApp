using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Interfaces
{
    public interface IDistanceService
    {
        Double GetDistance(IEnumerable<Point> points);
    }
}
