using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApp.Models;
using TestApp.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApp.Controllers
{
    [Route("api/Point")]
    public class PointController : Controller
    {
        private readonly IPointRepository pointRepository;
        private readonly IPointHistoryService pointHistoryService;

        public PointController(IPointRepository pointRepository, IPointHistoryService pointHistoryService)
        {
            this.pointRepository = pointRepository ?? throw new ArgumentNullException();
            this.pointHistoryService = pointHistoryService ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public IEnumerable<Point> GetAll()
        {
            return pointRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(Guid id)
        {
            var item = pointRepository.Get(id);
            if (item == null)
                return NotFound();
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Point item)
        {
            if (item == null)
                return BadRequest();

            pointRepository.Add(item);
            pointHistoryService.AddHistory(item, PointHistoryType.Create);
            return Json(item);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Point item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            pointHistoryService.AddHistory(item, PointHistoryType.Edit);
            pointRepository.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            pointHistoryService.AddHistory(pointRepository.Get(id), PointHistoryType.Delete);
            pointRepository.Remove(id);
            return new NoContentResult();
        }
    }
}
