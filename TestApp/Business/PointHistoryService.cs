using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Data;
using TestApp.Interfaces;
using TestApp.Models;

namespace TestApp.Business
{
    public class PointHistoryService : IPointHistoryService
    {
        private IPointRepository pointRepository { get; set; } 
        private PointContext pointContext { get; set; }

        public PointHistoryService(IPointRepository pointRepository, PointContext pointContext)
        {
            this.pointRepository = pointRepository ?? throw new ArgumentNullException("pointHistoryService");
            this.pointContext = pointContext ?? throw new ArgumentNullException("pointHistoryService");
        }

        public IEnumerable<PointHistory> GetHistory()
        {
            return pointContext.PointsHistory.OrderBy(ph => ph.ChangedOn).ToList();
        }

        public void AddHistory(Point point, PointHistoryType historyType)
        {
            if (point == null)
                throw new ArgumentNullException();

            switch (historyType)
            {
                case PointHistoryType.Create:
                    AddCreateHistory(point);
                    break;
                case PointHistoryType.Edit:
                    AddEditHistory(point);
                    break;
                case PointHistoryType.Delete:
                    AddDeleteHistory(point);
                    break;
            }
            pointContext.SaveChanges();
        }

        private void AddCreateHistory(Point point)
        {
            var pointHistory = new PointHistory()
            {
                PointId = point.Id,
                NewDate = point.Date,
                NewLatitude = point.Latitude,
                NewLongitude = point.Longitude,
                NewNotes = point.Notes,
                ChangedOn = DateTime.Now,
                Action = PointHistoryType.Create
            };
            pointContext.PointsHistory.Add(pointHistory);
        }

        private void AddEditHistory(Point point)
        {
            var oldPoint = pointRepository.Get(point.Id);

            var pointHistory = new PointHistory()
            {
                PointId = point.Id,
                OldDate = oldPoint.Date,
                OldLatitude = oldPoint.Latitude,
                OldLongitude = oldPoint.Longitude,
                OldNotes = oldPoint.Notes,
                NewDate = DateTime.Now,
                NewLatitude = point.Latitude,
                NewLongitude = point.Longitude,
                NewNotes = point.Notes,
                ChangedOn = DateTime.Now,
                Action = PointHistoryType.Edit
            };
            pointContext.PointsHistory.Add(pointHistory);
        }

        private void AddDeleteHistory(Point point)
        {
            var pointHistory = new PointHistory()
            {
                PointId = point.Id,
                OldDate = point.Date,
                OldLatitude = point.Latitude,
                OldLongitude = point.Longitude,
                OldNotes = point.Notes,
                ChangedOn = DateTime.Now,
                Action = PointHistoryType.Delete
            };
            pointContext.PointsHistory.Add(pointHistory);
        }



    }
}
