using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebAPIConnectOK.Context;
using WebAPIConnectOK.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIConnectOK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        private readonly AppDbContext context;

        public PermisoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<PermisoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Permiso.ToList());
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        // GET api/<PermisoController>/5
        [HttpGet("{id}", Name = "GetPermiso")]
        public ActionResult Get(int id)
        {
            try
            {
                var permiso = context.Permiso.FirstOrDefault(p => p.Id == id);
                return Ok(permiso);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        // POST api/<PermisoController>
        [HttpPost]
        public ActionResult Post([FromBody] Permiso permiso)
        {
            try
            {
                context.Permiso.Add(permiso);

                context.SaveChanges();
                return CreatedAtRoute("GetPermiso", new { id = permiso.Id }, permiso);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        // PUT api/<PermisoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Permiso permiso)
        {
            try
            {
                if (permiso.Id.Equals(id))
                {
                    context.Entry(permiso).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetPermiso", new { id = permiso.Id }, permiso);
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

        // DELETE api/<PermisoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var permiso = context.Permiso.FirstOrDefault(p => p.Id == id);
                if (!permiso.Id.Equals(null))
                {
                    context.Permiso.Remove(permiso);
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
