using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using StoreApplication.Models;

namespace StoreApplication.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Index page.
        /// </summary>
        /// <returns>Home page.</returns>
        public ActionResult Index()
        {
            return View(DAL.Database.ListOfItems);
        }

        /// <summary>
        /// Delete item.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Index page with list.</returns>
        public ActionResult Delete(Guid id)
        {
            var selectedItem = DAL.Database.ListOfItems.Find(item => item.Id == id);
            DAL.Database.ListOfItems.Remove(selectedItem);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Cancel request.
        /// </summary>
        /// <returns>Home page.</returns>
        public ActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Back to home page.
        /// </summary>
        /// <returns>Home page.</returns>
        public ActionResult Back()
        {
            return RedirectToAction("Index");
        }

        /// <summary>
        /// New item to list.
        /// </summary>
        /// <returns>New item page.</returns>
        public ActionResult NewItem()
        {
            return View(new Item());
        }

        /// <summary>
        /// Save new item.
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>List of items.</returns>
        [HttpPost]
        public ActionResult NewItem(Item item)
        {
            item.Id = Guid.NewGuid();
            
            DAL.Database.ListOfItems.Add(item);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Item details.
        /// </summary>
        /// <returns>Item details view.</returns>
        public ActionResult ItemDetails(Guid id)
        {
            return View(DAL.Database.ListOfItems.Find(item => item.Id == id));
        }

        /// <summary>
        /// More details.
        /// </summary>
        /// <returns>List of items view.</returns>
        public ActionResult MoreDetails()
        {
            return View(DAL.Database.ListOfItems);
        }
    }
}