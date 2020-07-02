using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhoneBookDataAccess;
namespace PhoneBookService.Controllers
{
    public class PhoneBookController : ApiController
    {
        // GET: api/PhoneBook

        //public IEnumerable<PhoneBook> Get()
        //{
        //    using (CIB_PhoneBookEntities entities = new CIB_PhoneBookEntities())
        //    {

        //    }
        //}
        //public IEnumerable<PhoneBook> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/PhoneBook/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PhoneBook
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PhoneBook/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PhoneBook/5
        public void Delete(int id)
        {
        }
    }
}
