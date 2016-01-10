using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreApplication.Models;
using StoreApplication.Entities;

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
            StoreAppDBEntities DataBase = new StoreAppDBEntities();
            List<StoreApplication.Entities.Item> entityList = DataBase.Items.ToList();
            List<StoreApplication.Models.ItemModel> modelList = new List<Models.ItemModel>();

            foreach (var item in entityList)
            {
                ItemModel newItem = new ItemModel();
                newItem.Id = item.Id;
                newItem.Name = item.Name;
                newItem.Description = item.Description;
                newItem.Category = item.Category;
                newItem.Price = item.Price;

                modelList.Add(newItem);
            }

            return View(modelList);
        }

        /// <summary>
        /// Delete item.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Index page with list.</returns>
        public ActionResult Delete(Guid id)
        {
            StoreAppDBEntities Database = new StoreAppDBEntities();
            var selectedItem = Database.Items.ToList().Find(item => item.Id == id);
            Database.Items.Remove(selectedItem);
            Database.SaveChanges();
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
            return View(new StoreApplication.Models.ItemModel());
        }

        /// <summary>
        /// Save new item.
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>List of items.</returns>
        [HttpPost]
        public ActionResult NewItem(StoreApplication.Models.ItemModel item)
        {
            if (ModelState.IsValid)
            {
                item.Id = Guid.NewGuid();

                Item entity = new Item();
                entity.Id = item.Id;
                entity.Name = item.Name;
                entity.Description = item.Description;
                entity.Category = item.Category;
                entity.Price = item.Price;

                StoreAppDBEntities Database = new StoreAppDBEntities();
                Database.Items.Add(entity);
                Database.SaveChanges();
                
                return RedirectToAction("Index");
            }
            else
                return View();

        }

        /// <summary>
        /// Item details.
        /// </summary>
        /// <returns>Item details view.</returns>
        public ActionResult ItemDetails(Guid id)
        {
            StoreAppDBEntities Database = new StoreAppDBEntities();
            var selectedItem = Database.Items.ToList().Find(item => item.Id == id);

            ItemModel itemModel = new ItemModel();
            itemModel.Id = selectedItem.Id;
            itemModel.Description = selectedItem.Description;
            itemModel.Name = selectedItem.Name;
            itemModel.Category = selectedItem.Category;
            itemModel.Price = selectedItem.Price;

            return View(itemModel);
        }

        /// <summary>
        /// More details.
        /// </summary>
        /// <returns>List of items view.</returns>
        public ActionResult MoreDetails()
        {
            StoreAppDBEntities Database = new StoreAppDBEntities();

            List<ItemModel> modelList = new List<ItemModel>();
            List<Item> entityList = Database.Items.ToList();

            foreach (var item in entityList)
            {
                ItemModel modelItem = new ItemModel();
                modelItem.Id = item.Id;
                modelItem.Name = item.Name;
                modelItem.Description = item.Description;
                modelItem.Category = item.Category;
                modelItem.Price = item.Price;

                modelList.Add(modelItem);
            }

            return View(modelList);
        }
    }
}