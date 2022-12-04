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
using WebAppS2.Models;

namespace WebAppS2.Controllers
{
    public class PrintersController : ApiController
    {
        private computerEntities db = new computerEntities();

        // GET: api/Printers
        public IQueryable<Printer> GetPrinter()
        {
            return db.Printer;
        }

        // GET: api/Printers/5
        [ResponseType(typeof(Printer))]
        public IHttpActionResult GetPrinter(int id)
        {
            Printer printer = db.Printer.Find(id);
            if (printer == null)
            {
                return NotFound();
            }

            return Ok(printer);
        }

        // PUT: api/Printers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrinter(int id, Printer printer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != printer.code)
            {
                return BadRequest();
            }

            db.Entry(printer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrinterExists(id))
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

        // POST: api/Printers
        [ResponseType(typeof(Printer))]
        public IHttpActionResult PostPrinter(Printer printer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Printer.Add(printer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PrinterExists(printer.code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = printer.code }, printer);
        }

        // DELETE: api/Printers/5
        [ResponseType(typeof(Printer))]
        public IHttpActionResult DeletePrinter(int id)
        {
            Printer printer = db.Printer.Find(id);
            if (printer == null)
            {
                return NotFound();
            }

            db.Printer.Remove(printer);
            db.SaveChanges();

            return Ok(printer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrinterExists(int id)
        {
            return db.Printer.Count(e => e.code == id) > 0;
        }
    }
}