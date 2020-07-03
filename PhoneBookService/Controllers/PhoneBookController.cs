using System;
using System.Linq;
using System.Web.Http;
using System.Collections.Generic;
using PhoneBookDataAccess;
using PhoneBookService.Models;
using AutoMapper;

namespace PhoneBookService.Controllers
{
    public class PhoneBookController : ApiController
    {
        
        public PhoneBookController() {
             

        }


        #region Get / Select Data from PhoneBook or PhoneBookEntry
        public IHttpActionResult GetPhoneBooks(bool includeActive)
        {
            IList<PhoneBookViewModel> phoneBooks = null;
            var dbToModelconfig = new MapperConfiguration(cfg => 
            cfg.CreateMap<PhoneBook, PhoneBookViewModel>());

            var mapper = new Mapper(dbToModelconfig);
            using (var pbEntities = new CIB_PhoneBookEntities())
            {
                //var pbook = mapper.Map<PhoneBookViewModel>(pbEntities.PhoneBooks);
                
            }
                
                
            

            
            
            using (var pbEntities = new CIB_PhoneBookEntities())
            {
                

                phoneBooks = pbEntities.PhoneBooks.Include("PhoneBookEntries")
                           .Select(pb => new PhoneBookViewModel()
                           {
                               phonebookid  = pb.phonebookid,
                               name         = pb.name,
                               datecreated  = pb.datecreated,
                               datemodified = pb.datemodified,
                               active       = pb.active,
                               }).ToList();
                               /*PhoneBookEntries = new List<PhoneBookEntry>().Add(new PhoneBookEntry() {

                               }
                               
                           }).ToList<PhoneBookEntryViewModel>();*/

                
            }

            if (phoneBooks.Count == 0)
            {
                return NotFound();
            }

            return Ok(phoneBooks);
        }

        public IHttpActionResult GetPhoneBookEntries(int phoneBookId)
        {
            IList<PhoneBookEntryViewModel> phoneBookEntries = null;

            using (var pbEntities = new CIB_PhoneBookEntities())
            {
                phoneBookEntries = pbEntities.PhoneBookEntries
                           .Where(pbe => pbe.phonebookid == phoneBookId)
                           .Select(pbe => new PhoneBookEntryViewModel()
                           {
                               phonebookentryid = pbe.phonebookentryid,
                               phonebookid = pbe.phonebookid,
                               name = pbe.name,
                               datecreated = pbe.datecreated,
                               datemodified = pbe.datemodified,
                               active = pbe.active
                           }).ToList<PhoneBookEntryViewModel>();
            }

            if (phoneBookEntries.Count == 0)
            {
                return NotFound();
            }

            return Ok(phoneBookEntries);
        }

        public IHttpActionResult GetPhoneBookEntry(int phoneBookEntryId)
        {
            PhoneBookEntryViewModel phoneBookEntry = null;

            using (var pbEntity = new CIB_PhoneBookEntities())
            {                
                phoneBookEntry = pbEntity.PhoneBookEntries.Where(pbe => pbe.phonebookentryid == phoneBookEntryId)
                    .Select(pbe => new PhoneBookEntryViewModel()
                    {
                        phonebookentryid = pbe.phonebookentryid,
                        phonebookid = pbe.phonebookid,
                        name = pbe.name,
                        datecreated = pbe.datecreated,
                        datemodified = pbe.datemodified,
                        active = pbe.active
                    })as PhoneBookEntryViewModel;
            }

            if (phoneBookEntry == null)
            {
                return NotFound();
            }

            return Ok(phoneBookEntry);
        }

        #endregion



        #region Post / Insert Data into PhoneBook or PhoneBookEntry api/PhoneBook
        public IHttpActionResult PostNewPhoneBook(PhoneBookViewModel phoneBook)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var pb = new CIB_PhoneBookEntities())
            {
                pb.PhoneBooks.Add(new PhoneBook()
                {
                    name = phoneBook.name,
                    datecreated = DateTime.Now,
                    datemodified = DateTime.Now,
                    active = phoneBook.active
                    
                });

                pb.SaveChanges();
            }

            return Ok();
        }
        public IHttpActionResult PostNewPhoneBookEntry(PhoneBookEntryViewModel phoneBookEntry)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            

            using (var pb = new CIB_PhoneBookEntities())
            {
                pb.PhoneBookEntries.Add(new PhoneBookEntry()
                {
                    phonebookid = phoneBookEntry.phonebookid,                    
                    name = phoneBookEntry.name,
                    phonenumber = phoneBookEntry.phonenumber,
                    datecreated = DateTime.Now,
                    datemodified = DateTime.Now,
                    active = phoneBookEntry.active

                });

                pb.SaveChanges();
            }

            return Ok();
        }
        #endregion



        #region Put / Update PhoneBook or PhoneBookEntry
        public IHttpActionResult Put(PhoneBookViewModel phoneBookViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            PhoneBookViewModel existingPhoneBook = null;

            using (var phoneBookEntities = new CIB_PhoneBookEntities())
            {
                existingPhoneBook = phoneBookEntities.PhoneBooks.Where(pb => pb.phonebookid == phoneBookViewModel.phonebookid) as PhoneBookViewModel;

                if (existingPhoneBook != null)
                {
                    existingPhoneBook.name = phoneBookViewModel.name;
                    existingPhoneBook.datemodified = DateTime.Now;

                    phoneBookEntities.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        public IHttpActionResult Put(PhoneBookEntryViewModel phoneBookEntryViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid PhoneBookEntryViewModel");

            PhoneBookEntryViewModel existingPhoneBookEntry = null;

            using (var phoneBookEntities = new CIB_PhoneBookEntities())
            {
                existingPhoneBookEntry = phoneBookEntities.PhoneBookEntries.Where(pb => pb.phonebookentryid == phoneBookEntryViewModel.phonebookentryid) as PhoneBookEntryViewModel;

                if (existingPhoneBookEntry != null)
                {
                    existingPhoneBookEntry.name = phoneBookEntryViewModel.name;
                    existingPhoneBookEntry.phonenumber = phoneBookEntryViewModel.phonenumber;
                    existingPhoneBookEntry.datemodified = DateTime.Now;

                    phoneBookEntities.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }
        #endregion

        //// DELETE: api/PhoneBook/5
        //public void Delete(int id)
        //{
        //}
    }
}
