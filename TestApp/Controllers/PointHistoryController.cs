using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApp.Interfaces;
using TestApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApp.Controllers
{
    [Route("api/PointHistory")]
    public class PointHistoryController : Controller
    {
        private readonly IPointHistoryService pointHistoryService;
        
        public PointHistoryController(IPointHistoryService pointHistoryService)
        {
            this.pointHistoryService = pointHistoryService ?? throw new ArgumentNullException("PointHistoryController");
        }

        [HttpGet]
        public IEnumerable<PointHistory> Get()
        {
            return pointHistoryService.GetHistory();
        }
    }
}
