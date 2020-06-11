using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRest.Context;
using WebApiRest.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    public class ContactoController : Controller
    {
        private readonly Context.AppContext context;

        public ContactoController(Context.AppContext context)
        {
            this.context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Contacto> Get()
        {
            return context.contacto.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Contacto Get(int id)
        {
            var contacto = context.contacto.FirstOrDefault(c => c.idContacto == id);
            return contacto;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Contacto contacto)
        {
            var valida = context.contacto.FirstOrDefault(c => c.nombreCompleto == contacto.nombreCompleto);
            if(valida == null)
            {
                try
                {
                    context.contacto.Add(contacto);
                    context.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }

            }
            else
            {
                return BadRequest("El registro ya existe");
            }
           
            
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Contacto contacto)
        {
            if(contacto.idContacto == id)
            {
                context.Entry(contacto).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var contacto = context.contacto.FirstOrDefault(c => c.idContacto == id);
            if(contacto != null)
            {
                context.contacto.Remove(contacto);
                context.SaveChanges();
                return Ok();
            }
            else
            {
               return BadRequest();
            }
        }
    }
}
