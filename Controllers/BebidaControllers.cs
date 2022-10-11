using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracticaTI.Models;
using PracticaTI.Services;

namespace PracticaTI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BebidaControllers : ControllerBase
    {
        public BebidaControllers()
        {


        }

        [HttpGet]
        public ActionResult<List<Bebida>> GetAll() => BebidaService.GetAll();

        [HttpGet("{iD}")]

        public ActionResult<Bebida> Get (int iD)
        {
            var Bebida = BebidaService.Get(iD);
            if(Bebida == null)
            
                return NotFound();

                return Bebida;
            
            
            
        }

        [HttpPost]

        public IActionResult Create(Bebida bebida)
        {
            BebidaService.Add(bebida);
            return CreatedAtAction(nameof(Create),new {iD = bebida},bebida);
        }


        [HttpDelete("{iD}")]
        public IActionResult Delete(int iD)
        {
            var bebida = BebidaService.Get(iD);
            if(bebida is null)
            return NotFound();

            BebidaService.Delete(iD);

            return NoContent();
        }

        [HttpPut("{iD}")]
        public IActionResult Update(int iD, Bebida bebida)
        {
            if (iD != bebida.  ID)
            return BadRequest();

            var existingBebida = BebidaService.Get(iD);
            if (existingBebida is null)
            return NotFound();

            BebidaService.Update(bebida);

            return NoContent();
        }


    



        
    }
}