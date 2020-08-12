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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using PhoneBook.DAL;
using PhoneBookWebService.BasicAuthentication;

namespace PhoneBookWebService.Controllers
{
    [EnableCors(origins: "https://localhost:44305", headers: "*", methods: "*")]
    [BasicAuthentication]
    public class PeopleController : ApiController
    {
        private readonly PhoneBookContext db = new PhoneBookContext();

        // GET: api/People
        public IQueryable<People> GetPeoples()
        {
           
            return db.Peoples.Where(p=>p.IsActive);
        }

        // GET: api/People/5
        [ResponseType(typeof(People))]
        public async Task<IHttpActionResult> GetPeople(int id)
        {
            People people = await db.Peoples.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPeople(int id, People people)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != people.ID)
            {
                return BadRequest();
            }

            db.Entry(people).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleExists(id))
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

        // POST: api/People
        [ResponseType(typeof(People))]
        public async Task<IHttpActionResult> PostPeople(People people)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Peoples.Add(people);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = people.ID }, people);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(People))]
        public async Task<IHttpActionResult> DeletePeople(int id)
        {
            People people = await db.Peoples.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            db.Peoples.Remove(people);
            await db.SaveChangesAsync();

            return Ok(people);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeopleExists(int id)
        {
            return db.Peoples.Count(e => e.ID == id) > 0;
        }
    }
}