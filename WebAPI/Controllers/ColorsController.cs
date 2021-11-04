using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;  
        }
        [HttpGet]

        public IActionResult GetAll() 
        {
           var result= _colorService.GetAll();
            return Ok(result);
        
        }
        [HttpPost]

        public IActionResult Update(Color color) 
        {
            var result = _colorService.Update(color);
            return Ok(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Color color) 
        {
            var result = _colorService.Add(color);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            return Ok(result);
        }
    }
}
