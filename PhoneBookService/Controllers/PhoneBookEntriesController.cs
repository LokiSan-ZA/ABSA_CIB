using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneBookDataAccess;

namespace PhoneBookService.Controllers
{
    public class PhoneBookEntriesController : Controller
    {
        private CIB_PhoneBookEntities db = new CIB_PhoneBookEntities();

        // GET: PhoneBookEntries
        public ActionResult Index()
        {
            var phoneBookEntries = db.PhoneBookEntries.Include(p => p.PhoneBook);
            return View(phoneBookEntries.ToList());
        }

        // GET: PhoneBookEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneBookEntry phoneBookEntry = db.PhoneBookEntries.Find(id);
            if (phoneBookEntry == null)
            {
                return HttpNotFound();
            }
            return View(phoneBookEntry);
        }

        // GET: PhoneBookEntries/Create
        public ActionResult Create()
        {
            ViewBag.phonebookid = new SelectList(db.PhoneBooks, "phonebookid", "name");
            return View();
        }

        // POST: PhoneBookEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "phonebookentryid,phonebookid,name,phonenumber,datecreated,datemodified,active")] PhoneBookEntry phoneBookEntry)
        {
            if (ModelState.IsValid)
            {
                db.PhoneBookEntries.Add(phoneBookEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.phonebookid = new SelectList(db.PhoneBooks, "phonebookid", "name", phoneBookEntry.phonebookid);
            return View(phoneBookEntry);
        }

        // GET: PhoneBookEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneBookEntry phoneBookEntry = db.PhoneBookEntries.Find(id);
            if (phoneBookEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.phonebookid = new SelectList(db.PhoneBooks, "phonebookid", "name", phoneBookEntry.phonebookid);
            return View(phoneBookEntry);
        }

        // POST: PhoneBookEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "phonebookentryid,phonebookid,name,phonenumber,datecreated,datemodified,active")] PhoneBookEntry phoneBookEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phoneBookEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.phonebookid = new SelectList(db.PhoneBooks, "phonebookid", "name", phoneBookEntry.phonebookid);
            return View(phoneBookEntry);
        }

        // GET: PhoneBookEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneBookEntry phoneBookEntry = db.PhoneBookEntries.Find(id);
            if (phoneBookEntry == null)
            {
                return HttpNotFound();
            }
            return View(phoneBookEntry);
        }

        // POST: PhoneBookEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneBookEntry phoneBookEntry = db.PhoneBookEntries.Find(id);
            db.PhoneBookEntries.Remove(phoneBookEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
