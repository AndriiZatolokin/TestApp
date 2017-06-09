using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;
using TestApp.Interfaces;

namespace TestApp.Controllers
{
    [Route("api/Distance")]
    public class DistanceController : Controller
    {
        private readonly IPointRepository pointRepository;
        private readonly IDistanceService distanceService;

        public DistanceController(IPointRepository pointRepository, IDistanceService distanceService)
        {
            this.pointRepository = pointRepository;
            this.distanceService = distanceService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var distance = distanceService.GetDistance( pointRepository.GetAll());
            return Json(new { distance = distance });
        }

    }
}
