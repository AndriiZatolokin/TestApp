using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Interfaces
{
    public interface IPointHistoryService
    {
        void AddHistory(Point point, PointHistoryType historyType);
        IEnumerable<PointHistory> GetHistory();
    }
}
