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
    public class PhoneBooksController : Controller
    {
        private CIB_PhoneBookEntities db = new CIB_PhoneBookEntities();

        // GET: PhoneBooks
        public ActionResult Index()
        {
            return View(db.PhoneBooks.ToList());
        }

        // GET: PhoneBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneBook phoneBook = db.PhoneBooks.Find(id);
            if (phoneBook == null)
            {
                return HttpNotFound();
            }
            return View(phoneBook);
        }

        // GET: PhoneBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "phonebookid,name,datecreated,datemodified,active")] PhoneBook phoneBook)
        {
            if (ModelState.IsValid)
            {
                db.PhoneBooks.Add(phoneBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phoneBook);
        }

        // GET: PhoneBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneBook phoneBook = db.PhoneBooks.Find(id);
            if (phoneBook == null)
            {
                return HttpNotFound();
            }
            return View(phoneBook);
        }

        // POST: PhoneBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "phonebookid,name,datecreated,datemodified,active")] PhoneBook phoneBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phoneBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phoneBook);
        }

        // GET: PhoneBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneBook phoneBook = db.PhoneBooks.Find(id);
            if (phoneBook == null)
            {
                return HttpNotFound();
            }
            return View(phoneBook);
        }

        // POST: PhoneBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneBook phoneBook = db.PhoneBooks.Find(id);
            db.PhoneBooks.Remove(phoneBook);
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
