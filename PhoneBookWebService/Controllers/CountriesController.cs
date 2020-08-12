using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data;
using PhoneBook.Service;
using PhoneBook.DAL;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Cors;
using System.Web.UI;
using System.Data.Odbc;
using PhoneBookWebService.BasicAuthentication;

namespace PhoneBookWebService.Controllers
{
    [EnableCors(origins: "https://localhost:44305", headers: "*", methods: "*")]
    [BasicAuthentication]
    public class CountriesController : ApiController
    {

        readonly CountryService  countryService;
        public CountriesController()
        {
            countryService = new CountryService();
        }
        
        public IEnumerable<Country> Get()
        {
            return countryService.GetCountries();
        }

        public IEnumerable<Country> Get(int id)
        {
           
            return countryService.GetCountries(id);
        }


       
        public HttpStatusCode Post(Country country)
        {
            return countryService.PostCountries(country);
        }

        [HttpPatch]
        public IHttpActionResult Patch(Country country)
        {
            if (country != null)
            {
                try
                {
                    countryService.UpdateCountries(country);
                }
                catch(Exception e)
                {
                   
                    return Content(HttpStatusCode.NotFound, e.Message);
                }
                return Ok("Country updated");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Country Parameters cannot be noll");
            }

        }

        [HttpDelete]
        public IHttpActionResult Delete(Country country)
        {
            if(country!=null)
            {
                countryService.DeleteCouuntries(country);
                return Ok("Country Deleted");
            }
            else
            {
                return NotFound();
            }
            
        }


    }
}
