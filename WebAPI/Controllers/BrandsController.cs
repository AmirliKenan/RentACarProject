using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandmanager;
        public BrandsController(IBrandService brandmanager)
        {
            _brandmanager = brandmanager;
        }
        [HttpGet]
        public IActionResult GetAll() 
        {

            var result = _brandmanager.GetAll();
            if (result.Success) 
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {

            var result = _brandmanager.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
    }
}
