using Business.Abstract;
using Business.Constants;
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
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getRentalDetail")]
        public IActionResult GetRentalDetail(int rentalId)
        {
            var result = _rentalService.GetRentalDetail(rentalId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(Messages.InvalidRentalId);
            
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getByCarId")]
        public IActionResult GetByCarId(int id)
        {
            var result = _rentalService.GetByCarId( id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getByCustomerId")]
        public IActionResult GetByCustomerId(short id)
        {
            var result = _rentalService.GetByCustomerId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getByRentDate")]
        public IActionResult GetByRentDate(DateTime rentTime)
        {
            var result = _rentalService.GetByRentDate(rentTime);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getByReturnDate")]
        public IActionResult GetByReturnDate(DateTime returnTime)
        {
            var result = _rentalService.GetByReturnDate(returnTime);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }



    }
}
