using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIConnectOK.Context;
using WebAPIConnectOK.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIConnectOK.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TipoPermisoController : ControllerBase
    {
        private readonly AppDbContext context;

        public TipoPermisoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<TipoPermisoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
           
                return Ok(context.TipoPermiso.ToList());

            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        // GET api/<TipoPermisoController>/5
        [HttpGet("{id}", Name = "GetTipoPermiso")]
        public ActionResult Get(int id)
        {
            try
            {
                var permiso = context.TipoPermiso.FirstOrDefault(p => p.Id == id);
                return Ok(permiso);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        // POST api/<TipoPermisoController>
        [HttpPost]
        public ActionResult Post([FromBody] TipoPermiso tipoPermiso)
        {
            try
            {
                context.TipoPermiso.Add(tipoPermiso);

                context.SaveChanges();
                return CreatedAtRoute("GetTipoPermiso", new { id = tipoPermiso.Id }, tipoPermiso);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }


        // PUT api/<TipoPermisoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TipoPermiso tipoPermiso)
        {
            try
            {
                if (tipoPermiso.Id.Equals(id))
                {
                    context.Entry(tipoPermiso).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetTipoPermiso", new { id = tipoPermiso.Id }, tipoPermiso);
                }
                else
                {
                    return BadRequest();
                }

            }

            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
        // DELETE api/<TipoPermisoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var tipoPermiso = context.TipoPermiso.FirstOrDefault(p => p.Id == id);
                if (!tipoPermiso.Id.Equals(null))
                {
                    context.TipoPermiso.Remove(tipoPermiso);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
    }
}
