using Business.Abstract;
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
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getById")]
        public IActionResult GetById(short id)
        {
            var result = _colorService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Create([FromQuery] string colorName)
        {
            try
            {
                _colorService.Add(new Color { Name = colorName });
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(short id, [FromBody] Color newColor)
        {
            var result = _colorService.GetById(id);
            if (result is not null)
            {
                try
                {
                    result.Data.Name = newColor.Name;
                    _colorService.Update(result.Data);
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
