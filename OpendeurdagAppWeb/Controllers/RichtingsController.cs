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
using OpendeurdagAppWeb.Models;

namespace OpendeurdagAppWeb.Controllers
{
    public class RichtingsController : ApiController
    {
        private OpendeurdagAppWebContext db = new OpendeurdagAppWebContext();

        // GET: api/Richtings
        public IQueryable<Richting> GetRichtings()
        {
            return db.Richtings;
        }

        // GET: api/Richtings/5
        [ResponseType(typeof(Richting))]
        public IHttpActionResult GetRichting(int id)
        {
            Richting richting = db.Richtings.Find(id);
            if (richting == null)
            {
                return NotFound();
            }

            return Ok(richting);
        }

        // PUT: api/Richtings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRichting(int id, Richting richting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != richting.RichtingId)
            {
                return BadRequest();
            }

            db.Entry(richting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RichtingExists(id))
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

        // POST: api/Richtings
        [ResponseType(typeof(Richting))]
        public IHttpActionResult PostRichting(Richting richting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Richtings.Add(richting);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = richting.RichtingId }, richting);
        }

        // DELETE: api/Richtings/5
        [ResponseType(typeof(Richting))]
        public IHttpActionResult DeleteRichting(int id)
        {
            Richting richting = db.Richtings.Find(id);
            if (richting == null)
            {
                return NotFound();
            }

            db.Richtings.Remove(richting);
            db.SaveChanges();

            return Ok(richting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RichtingExists(int id)
        {
            return db.Richtings.Count(e => e.RichtingId == id) > 0;
        }
    }
}