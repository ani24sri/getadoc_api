using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using getadoc_api.Models;

namespace getadoc_api.Controllers
{
    public class PatientsController : ApiController
    {
        private getadocDbContext db = new getadocDbContext();

        // GET: api/Patients
        public IQueryable<Patients> GetPatients()
        {
            return db.Patients;
        }

        // GET: api/Patients/5
        [ResponseType(typeof(Patients))]
        public async Task<IHttpActionResult> GetPatients(int id)
        {
            Patients patients = await db.Patients.FindAsync(id);
            if (patients == null)
            {
                return NotFound();
            }

            return Ok(patients);
        }

        // PUT: api/Patients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPatients(int id, Patients patients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patients.id)
            {
                return BadRequest();
            }

            db.Entry(patients).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientsExists(id))
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

        // POST: api/Patients
        [ResponseType(typeof(Patients))]
        public async Task<IHttpActionResult> PostPatients(Patients patients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Patients.Add(patients);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = patients.id }, patients);
        }

        // DELETE: api/Patients/5
        [ResponseType(typeof(Patients))]
        public async Task<IHttpActionResult> DeletePatients(int id)
        {
            Patients patients = await db.Patients.FindAsync(id);
            if (patients == null)
            {
                return NotFound();
            }

            db.Patients.Remove(patients);
            await db.SaveChangesAsync();

            return Ok(patients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientsExists(int id)
        {
            return db.Patients.Count(e => e.id == id) > 0;
        }
    }
}