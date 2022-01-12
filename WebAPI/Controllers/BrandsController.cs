using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
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
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Create([FromQuery] string brandName)
        {
            try
            {
                _brandService.Add(new Brand {Name=brandName});
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] Brand newBrand)
        {
            var result=  _brandService.GetById(id);
            if (result is not null)
            {
                try
                {
                    result.Data.Name = newBrand.Name;
                    _brandService.Update(result.Data);
                }
                catch (Exception)
                {

                    return StatusCode(500);
                }

                
            }
            return Ok();

        }


    }
}
