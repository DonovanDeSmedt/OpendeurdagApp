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
    public class NewsFeedItemsController : ApiController
    {
        private OpendeurdagAppWebContext db = new OpendeurdagAppWebContext();

        // GET: api/NewsFeedItems
        public IQueryable<NewsFeedItem> GetNewsFeedItems()
        {
            return db.NewsFeedItems;
        }

        // GET: api/NewsFeedItems/5
        [ResponseType(typeof(NewsFeedItem))]
        public IHttpActionResult GetNewsFeedItem(int id)
        {
            NewsFeedItem newsFeedItem = db.NewsFeedItems.Find(id);
            if (newsFeedItem == null)
            {
                return NotFound();
            }

            return Ok(newsFeedItem);
        }

        // PUT: api/NewsFeedItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNewsFeedItem(int id, NewsFeedItem newsFeedItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsFeedItem.NewsFeedItemId)
            {
                return BadRequest();
            }

            db.Entry(newsFeedItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsFeedItemExists(id))
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

        // POST: api/NewsFeedItems
        [ResponseType(typeof(NewsFeedItem))]
        public IHttpActionResult PostNewsFeedItem(NewsFeedItem newsFeedItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NewsFeedItems.Add(newsFeedItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newsFeedItem.NewsFeedItemId }, newsFeedItem);
        }

        // DELETE: api/NewsFeedItems/5
        [ResponseType(typeof(NewsFeedItem))]
        public IHttpActionResult DeleteNewsFeedItem(int id)
        {
            NewsFeedItem newsFeedItem = db.NewsFeedItems.Find(id);
            if (newsFeedItem == null)
            {
                return NotFound();
            }

            db.NewsFeedItems.Remove(newsFeedItem);
            db.SaveChanges();

            return Ok(newsFeedItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewsFeedItemExists(int id)
        {
            return db.NewsFeedItems.Count(e => e.NewsFeedItemId == id) > 0;
        }
    }
}