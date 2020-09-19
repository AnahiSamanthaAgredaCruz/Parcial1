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
using ParcialAnahiAgreda.Models;

namespace ParcialAnahiAgreda.Controllers
{
    public class AnahiAgredasController : ApiController
    {
        private DataContext db = new DataContext();
        [Authorize]
        // GET: api/AnahiAgredas
        public IQueryable<AnahiAgreda> GetAnahiAgredas()
        {
            return db.AnahiAgredas;
        }
        [Authorize]
        // GET: api/AnahiAgredas/5
        [ResponseType(typeof(AnahiAgreda))]
        public IHttpActionResult GetAnahiAgreda(string id)
        {
            AnahiAgreda anahiAgreda = db.AnahiAgredas.Find(id);
            if (anahiAgreda == null)
            {
                return NotFound();
            }

            return Ok(anahiAgreda);
        }
        [Authorize]
        // PUT: api/AnahiAgredas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnahiAgreda(string id, AnahiAgreda anahiAgreda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anahiAgreda.CodeThreeLetter)
            {
                return BadRequest();
            }

            db.Entry(anahiAgreda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnahiAgredaExists(id))
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
        [Authorize]
        // POST: api/AnahiAgredas
        [ResponseType(typeof(AnahiAgreda))]
        public IHttpActionResult PostAnahiAgreda(AnahiAgreda anahiAgreda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AnahiAgredas.Add(anahiAgreda);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AnahiAgredaExists(anahiAgreda.CodeThreeLetter))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = anahiAgreda.CodeThreeLetter }, anahiAgreda);
        }
        [Authorize]
        // DELETE: api/AnahiAgredas/5
        [ResponseType(typeof(AnahiAgreda))]
        public IHttpActionResult DeleteAnahiAgreda(string id)
        {
            AnahiAgreda anahiAgreda = db.AnahiAgredas.Find(id);
            if (anahiAgreda == null)
            {
                return NotFound();
            }

            db.AnahiAgredas.Remove(anahiAgreda);
            db.SaveChanges();

            return Ok(anahiAgreda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnahiAgredaExists(string id)
        {
            return db.AnahiAgredas.Count(e => e.CodeThreeLetter == id) > 0;
        }
    }
}