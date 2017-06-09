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

        public PointController(IPointRepository pointRepository)
        {
            this.pointRepository = pointRepository;

            if (pointRepository.GetAll().Count() == 0)
                pointRepository.Add(new Point { Notes = "Hello Dnipro", Latitude= 48.4608931, Longitude= 35.0485662 });
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
            return Json(item);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Point item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            pointRepository.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            pointRepository.Remove(id);
            return new NoContentResult();
        }
    }
}
