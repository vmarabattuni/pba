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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using PhoneBook.DAL;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using PhoneBookWebService.BasicAuthentication;
using System.Web.Http.Cors;

namespace PhoneBookWebService.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using PhoneBook.DAL;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<People>("PeopleOdata");
    builder.EntitySet<City>("Cities"); 
    builder.EntitySet<Country>("Countries"); 
    builder.EntitySet<State>("States"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    [BasicAuthentication]
    [EnableCors(origins: "https://localhost:44305", headers: "*", methods: "*")]
    public class PeopleOdataController : ODataController
    {
        private readonly PhoneBookContext db = new PhoneBookContext();

        // GET: odata/PeopleOdata
        [EnableQuery]
        public IQueryable<People> GetPeopleOdata()
        {
            return db.Peoples;
        }

        // GET: odata/PeopleOdata(5)
        [EnableQuery]
        public SingleResult<People> GetPeople([FromODataUri] int key)
        {
            return SingleResult.Create(db.Peoples.Where(people => people.ID == key));
        }

        // PUT: odata/PeopleOdata(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<People> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            People people = await db.Peoples.FindAsync(key);
            if (people == null)
            {
                return NotFound();
            }

            patch.Put(people);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(people);
        }

        // POST: odata/PeopleOdata
        public async Task<IHttpActionResult> Post(People people)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Peoples.Add(people);
            await db.SaveChangesAsync();

            return Created(people);
        }

        // PATCH: odata/PeopleOdata(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<People> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            People people = await db.Peoples.FindAsync(key);
            if (people == null)
            {
                return NotFound();
            }

            patch.Patch(people);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(people);
        }

        // DELETE: odata/PeopleOdata(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            People people = await db.Peoples.FindAsync(key);
            if (people == null)
            {
                return NotFound();
            }

            db.Peoples.Remove(people);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/PeopleOdata(5)/City
        [EnableQuery]
        public SingleResult<City> GetCity([FromODataUri] int key)
        {
            return SingleResult.Create(db.Peoples.Where(m => m.ID == key).Select(m => m.City));
        }

        // GET: odata/PeopleOdata(5)/Country
        [EnableQuery]
        public SingleResult<Country> GetCountry([FromODataUri] int key)
        {
            return SingleResult.Create(db.Peoples.Where(m => m.ID == key).Select(m => m.Country));
        }

        // GET: odata/PeopleOdata(5)/State
        [EnableQuery]
        public SingleResult<State> GetState([FromODataUri] int key)
        {
            return SingleResult.Create(db.Peoples.Where(m => m.ID == key).Select(m => m.State));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeopleExists(int key)
        {
            return db.Peoples.Count(e => e.ID == key) > 0;
        }
    }
}
