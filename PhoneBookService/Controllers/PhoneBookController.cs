using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhoneBookDataAccess;
namespace PhoneBookService.Controllers
{
    public class PhoneBookController : ApiController, IDisposable
    {
        // GET: api/PhoneBook
        //public HttpResponseMessage Get()
        //{
        //    List<PhoneBook> phoneBookList = new List<PhoneBook>();
        //    using (DbModel dc = new DbModel())
        //    {
        //        phoneBookList = dc.phoneBookList.OrderBy(a => a.Name).ToList();
        //        HttpResponseMessage response;
        //        response = Request.CreateResponse(HttpStatusCode.OK, phoneBookList);
        //        return response;
        //    }
        //}
        public IEnumerable<PhoneBook> Get()
        {
            using (CIB_PhoneBookEntities entities = new CIB_PhoneBookEntities())
            {
                var test = entities.PhoneBooks.ToList();
                return test;
            }
        }

        public IEnumerable<PhoneBookEntry> GetPhoneBook(int id)
        {
            using (CIB_PhoneBookEntities entities = new CIB_PhoneBookEntities())
            {
                return entities.PhoneBookEntries.Where(e => e.phonebookid == id);
            }
        }

        public PhoneBookEntry GetPhoneBookEntry(int id)
        {
            using (CIB_PhoneBookEntities entities = new CIB_PhoneBookEntities())
            {
                return entities.PhoneBookEntries.FirstOrDefault(e => e.phonebookentryid == id);
            }
        }
        // GET: api/PhoneBook/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/PhoneBook
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/PhoneBook/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/PhoneBook/5
        //public void Delete(int id)
        //{
        //}
    }
}
