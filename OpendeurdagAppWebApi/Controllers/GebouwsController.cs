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
using OpendeurdagAppWebApi.Models;

namespace OpendeurdagAppWebApi.Controllers
{
    public class GebouwsController : ApiController
    {
        private OpendeurdagAppWebApiContext db = new OpendeurdagAppWebApiContext();

        // GET: api/Gebouws
        public IQueryable<Gebouw> GetGebouws()
        {
            return db.Gebouws;
        }

        // GET: api/Gebouws/5
        [ResponseType(typeof(Gebouw))]
        public IHttpActionResult GetGebouw(int id)
        {
            Gebouw gebouw = db.Gebouws.Find(id);
            if (gebouw == null)
            {
                return NotFound();
            }

            return Ok(gebouw);
        }

        // PUT: api/Gebouws/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGebouw(int id, Gebouw gebouw)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gebouw.GebouwId)
            {
                return BadRequest();
            }

            db.Entry(gebouw).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GebouwExists(id))
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

        // POST: api/Gebouws
        [ResponseType(typeof(Gebouw))]
        public IHttpActionResult PostGebouw(Gebouw gebouw)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gebouws.Add(gebouw);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gebouw.GebouwId }, gebouw);
        }

        // DELETE: api/Gebouws/5
        [ResponseType(typeof(Gebouw))]
        public IHttpActionResult DeleteGebouw(int id)
        {
            Gebouw gebouw = db.Gebouws.Find(id);
            if (gebouw == null)
            {
                return NotFound();
            }

            db.Gebouws.Remove(gebouw);
            db.SaveChanges();

            return Ok(gebouw);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GebouwExists(int id)
        {
            return db.Gebouws.Count(e => e.GebouwId == id) > 0;
        }
    }
}