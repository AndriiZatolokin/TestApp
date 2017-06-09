using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Interfaces;
using TestApp.Models;

namespace TestApp.Business
{
    public class DistanceService : IDistanceService
    {
        public double GetDistance(IEnumerable<Point> points)
        {
            Double distance = 0;
            for(var i=0; i<points.Count()-1;i++)
            {
                distance += Distance(points.ElementAt(i), points.ElementAt(i + 1));
            }
            return distance;
        }

        private double Distance(Point point1, Point point2)
        {
            double R =  6371;

            
            double dLat = this.ToRadian(point2.Latitude - point1.Latitude);
            double dLon = this.ToRadian(point2.Longitude - point1.Longitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(this.ToRadian(point1.Latitude)) * Math.Cos(this.ToRadian(point2.Latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = R * c;

            return d;
        }

        private double ToRadian(double val)
        {
            return (Math.PI / 180) * val;
        }
    }
}
