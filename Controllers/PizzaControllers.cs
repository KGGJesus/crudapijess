using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaTI.Models;
using PracticaTI.Services;
using Microsoft.AspNetCore.Mvc;


namespace PracticaTI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaControllers : ControllerBase
    {
        public PizzaControllers()
        {


        }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        [HttpGet("{id}")]

        public ActionResult<Pizza> Get (int id)
        {
            var Pizza = PizzaService.Get(id);
            if(Pizza == null)
            
                return NotFound();

                return Pizza;
            
            
            
        }

        [HttpPost]

        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create),new {id = pizza},pizza);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);
            if(pizza is null)
            return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
            return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
            return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
        }


    



        
    }
}