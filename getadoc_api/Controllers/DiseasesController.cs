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
    public class DiseasesController : ApiController
    {
        private getadocDbContext db = new getadocDbContext();

        // GET: api/diseaseDatas
        public IQueryable<diseaseData> GetdiseaseDatas()
        {
            return db.diseaseDatas;
        }

        // GET: api/diseaseDatas/5
        [ResponseType(typeof(diseaseData))]
        public async Task<IHttpActionResult> GetdiseaseData(int id)
        {
            diseaseData diseaseData = await db.diseaseDatas.FindAsync(id);
            if (diseaseData == null)
            {
                return NotFound();
            }

            return Ok(diseaseData);
        }

        // PUT: api/diseaseDatas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutdiseaseData(int id, diseaseData diseaseData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diseaseData.id)
            {
                return BadRequest();
            }

            db.Entry(diseaseData).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!diseaseDataExists(id))
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

        // POST: api/diseaseDatas
        [ResponseType(typeof(diseaseData))]
        public async Task<IHttpActionResult> PostdiseaseData(diseaseData diseaseData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.diseaseDatas.Add(diseaseData);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = diseaseData.id }, diseaseData);
        }

        // DELETE: api/diseaseDatas/5
        [ResponseType(typeof(diseaseData))]
        public async Task<IHttpActionResult> DeletediseaseData(int id)
        {
            diseaseData diseaseData = await db.diseaseDatas.FindAsync(id);
            if (diseaseData == null)
            {
                return NotFound();
            }

            db.diseaseDatas.Remove(diseaseData);
            await db.SaveChangesAsync();

            return Ok(diseaseData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool diseaseDataExists(int id)
        {
            return db.diseaseDatas.Count(e => e.id == id) > 0;
        }
    }
}