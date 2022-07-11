using BookStoreAli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreAli.Controllers
{
    public class BookController : Controller
    {
        BookDb db = new BookDb();
        // GET: Book
        //Index
        public ActionResult BookDetails()
        {
            IEnumerable<Book> books = db.GetBooks();
            return View(books);
        }


        public ActionResult Create()
        {
            return View(new Book());
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (db.InsertBook(book))
                        return RedirectToAction(nameof(BookDetails));
                }

            }
            catch (Exception)
            {

                throw;
            }
            book.Categories.Where(b => b.Text.ToUpper() == book.Category.ToUpper()).First().Selected = true;

            return View(book);
        }


        public ActionResult Edit(int Id)
        {
            Book book = db.GetBook(Id);

            book.Categories.Where(b => b.Text.ToUpper() == book.Category.ToUpper()).First().Selected = true;
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (db.Update(book))
                        return RedirectToAction(nameof(BookDetails));
                }

            }
            catch (Exception)
            {

                throw;
            }

            return View(book);
        }


        [HttpPost]
        public ActionResult Delete(int? Id)
        {
            if (db.Delete(Id))
                return Json(new { success=true });
                //return RedirectToAction(nameof(BookDetails));
            return View();

        }
    }
}