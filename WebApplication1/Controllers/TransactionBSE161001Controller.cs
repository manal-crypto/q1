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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TransactionBSE161001Controller : ApiController
    {
        private BSE161001Entities db = new BSE161001Entities();

        // GET: api/TransactionBSE161001
        public IQueryable<TransactionBSE161001> GetTransactionBSE161001()
        {
            return db.TransactionBSE161001;
        }

        // GET: api/TransactionBSE161001/5
        [ResponseType(typeof(TransactionBSE161001))]
        public IHttpActionResult GetTransactionBSE161001(int id)
        {
            TransactionBSE161001 transactionBSE161001 = db.TransactionBSE161001.Find(id);
            if (transactionBSE161001 == null)
            {
                return NotFound();
            }

            return Ok(transactionBSE161001);
        }

        // PUT: api/TransactionBSE161001/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTransactionBSE161001(int id, TransactionBSE161001 transactionBSE161001)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transactionBSE161001.TransactionId)
            {
                return BadRequest();
            }

            db.Entry(transactionBSE161001).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionBSE161001Exists(id))
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

        // POST: api/TransactionBSE161001
        [ResponseType(typeof(TransactionBSE161001))]
        public IHttpActionResult PostTransactionBSE161001(TransactionBSE161001 transactionBSE161001)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TransactionBSE161001.Add(transactionBSE161001);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TransactionBSE161001Exists(transactionBSE161001.TransactionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = transactionBSE161001.TransactionId }, transactionBSE161001);
        }

        // DELETE: api/TransactionBSE161001/5
        [ResponseType(typeof(TransactionBSE161001))]
        public IHttpActionResult DeleteTransactionBSE161001(int id)
        {
            TransactionBSE161001 transactionBSE161001 = db.TransactionBSE161001.Find(id);
            if (transactionBSE161001 == null)
            {
                return NotFound();
            }

            db.TransactionBSE161001.Remove(transactionBSE161001);
            db.SaveChanges();

            return Ok(transactionBSE161001);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionBSE161001Exists(int id)
        {
            return db.TransactionBSE161001.Count(e => e.TransactionId == id) > 0;
        }
    }
}