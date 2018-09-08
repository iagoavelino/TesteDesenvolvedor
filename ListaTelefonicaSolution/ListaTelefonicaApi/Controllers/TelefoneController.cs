using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ListaTelefonicaApi.Models;

namespace ListaTelefonicaApi.Controllers
{
    public class TelefoneController : ApiController
    {
        private ListaTelefonicaDBEntities db = new ListaTelefonicaDBEntities();

        // GET: api/Telefone
        public IQueryable<Telefone> GetTelefones()
        {
            return db.Telefones;
        }

        // GET: api/Telefone/5
        [ResponseType(typeof(Telefone))]
        public IHttpActionResult GetTelefone(int id)
        {
            Telefone telefone = db.Telefones.Find(id);
            if (telefone == null)
            {
                return NotFound();
            }

            return Ok(telefone);
        }

        // PUT: api/Telefone/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTelefone(int id, Telefone telefone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telefone.id)
            {
                return BadRequest();
            }

            db.Entry(telefone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefoneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Telefone
        [ResponseType(typeof(Telefone))]
        public IHttpActionResult PostTelefone(Telefone telefone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Telefones.Add(telefone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = telefone.id }, telefone);
        }

        // DELETE: api/Telefone/5
        [ResponseType(typeof(Telefone))]
        public IHttpActionResult DeleteTelefone(int id)
        {
            Telefone telefone = db.Telefones.Find(id);
            if (telefone == null)
            {
                return NotFound();
            }

            db.Telefones.Remove(telefone);
            db.SaveChanges();

            return Ok(telefone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelefoneExists(int id)
        {
            return db.Telefones.Count(e => e.id == id) > 0;
        }
    }
}