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
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getByUserId")]
        public IActionResult GetByUserID(int id)
        {
            var result = _customerService.GetByUserID(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getByCompanyName")]
        public IActionResult GetByCompanyName(string companyName)
        {
            var result = _customerService.GetByCompanyName(companyName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
