using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Interfaces
{
    public interface IPointRepository
    {
        IEnumerable<Point> GetAll();
        void Add(Point item);
        Point Get(Guid id);
        Point Remove(Guid id);
        void Update(Point item);
    }
}
