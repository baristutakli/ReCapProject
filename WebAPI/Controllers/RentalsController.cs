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

        [HttpGet]
        public IActionResult GetRentalDetail(int rentalId)
        {
            var result = _rentalService.GetRentalDetail(rentalId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(Messages.InvalidRentalId);
            
        }
    }
}
