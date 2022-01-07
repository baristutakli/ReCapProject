using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getByBrandId")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getByColorId")]
        public IActionResult GetByColorId(short id)
        {
            var result = _carService.GetCarsByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getbyDailyPrice")]
        public IActionResult GetByDailyPrice(decimal min=0, decimal max=100)
        {
            var result = _carService.GetByDailyPrice(min, max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getByModelYear")]
        public IActionResult GetAllByModelYear(string year)
        {
            var result = _carService.GetAllByModelYear(year);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getBCarDetail")]
        public IActionResult GetCarDetail()
        {
            var result = _carService.GetProductDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


    }
}
