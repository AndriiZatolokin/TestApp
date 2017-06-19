using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Interfaces;
using TestApp.Models;

namespace TestApp.Data
{
    public class PointRepository : IPointRepository
    {
        private readonly PointContext pointContext;

        public PointRepository(PointContext context)
        {
            pointContext = context ?? throw new ArgumentNullException("PointRepository");
        }

        public IEnumerable<Point> GetAll()
        {
            return pointContext.Points.OrderBy(p => p.Date);
        }

        public void Add(Point item)
        {
            item.Id = Guid.NewGuid();
            item.Date = DateTime.Now;

            pointContext.Points.Add(item);
            pointContext.SaveChanges();
        }

        public Point Get(Guid id)
        {
            Point todo = pointContext.Points.AsNoTracking().FirstOrDefault(s => s.Id == id);
            return todo;
        }

        public Point Remove(Guid id)
        {
            Point point = pointContext.Points.FirstOrDefault(s => s.Id == id);
            pointContext.Points.Remove(point);
            pointContext.SaveChanges();

            return point;
        }

        public void Update(Point item)
        {
            Point point = pointContext.Points.FirstOrDefault(s => s.Id == item.Id);
            point.Latitude = item.Latitude;
            point.Longitude = item.Longitude;
            point.Notes = item.Notes;
            point.Date = DateTime.Now;
            pointContext.Points.Update(point);
            pointContext.SaveChanges();
        }
    }
}