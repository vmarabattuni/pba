using PhoneBook.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Http.Results;
using System.Web.Http.Controllers;
using System.Data.Entity.Migrations;

namespace PhoneBook.Service
{
    public class CountryService
    {
        PhoneBookContext phoneBookContext;
        public CountryService()
        {
            phoneBookContext = new PhoneBookContext();
        }
      
        public IEnumerable<Country> GetCountries()
        {
            return phoneBookContext.Countries.Where(x=>x.IsActive);
        }
        public IEnumerable<Country> GetCountries(int id)
        {
            return phoneBookContext.Countries.Where(x=>x.CuntryId.Equals(id) && x.IsActive);
        }

       
      
        public HttpStatusCode PostCountries(Country country)
        {
            phoneBookContext.Countries.Add(country);
            phoneBookContext.SaveChanges();
            return HttpStatusCode.OK;
        }

        public String UpdateCountries(Country country)
        {
            phoneBookContext.Countries.AddOrUpdate(country);
            phoneBookContext.SaveChanges();
            return "Country updated";
        }

        public HttpStatusCode DeleteCouuntries(Country country)
        {
            Country co = phoneBookContext.Countries.Where(x => x.CountryName.Contains(country.CountryName) || x.CuntryId.Equals(country.CuntryId)).FirstOrDefault();
            if (co != null)
            {
                phoneBookContext.Countries.Remove(co);
                phoneBookContext.SaveChanges();
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.NotFound;
            }
            
        }

    }
}
