using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreApplication.Models;
using StoreApplication.Entities;
using AutoMapper;

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
            StoreAppDBEntitiesEntities2 DataBase = new StoreAppDBEntitiesEntities2();
            List<StoreApplication.Entities.Item> entityList = DataBase.Item.ToList();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Item,ItemModel>()
               
                );
            var mapper = config.CreateMapper();

            List<ItemModel> listModels = mapper.Map<List<Item>, List<ItemModel>>(entityList);

            return View(listModels);
        }

        /// <summary>
        /// Delete item.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Index page with list.</returns>
        public ActionResult Delete(Guid id)
        {
            StoreAppDBEntitiesEntities2 Database = new StoreAppDBEntitiesEntities2();
            var selectedItem = Database.Item.ToList().Find(item => item.Id == id);
            Database.Item.Remove(selectedItem);
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
            StoreAppDBEntitiesEntities2 Database = new StoreAppDBEntitiesEntities2();
            ViewBag.Categories = new SelectList(Database.ItemCategory, "Id", "Category");

            return View(new StoreApplication.Models.ItemModel());
        }

        /// <summary>
        /// Save new item.
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>List of items.</returns>
        [HttpPost]
        public ActionResult NewItem(ItemModel item)
        {
            StoreAppDBEntitiesEntities2 Database = new StoreAppDBEntitiesEntities2();
            ViewBag.Categories = new SelectList(Database.ItemCategory, "Id", "Category");

            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ItemModel, Item>());
                var mapper = config.CreateMapper();

                item.Id = Guid.NewGuid();

                Item dbo = mapper.Map<Item>(item);

                //entity.Id = item.Id;
                //entity.Name = item.Name;
                //entity.Description = item.Description;
                //entity.CategoryId= item.CategoryId;
                //entity.Price = item.Price;

                Database.Item.Add(dbo);

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
            StoreAppDBEntitiesEntities2 Database = new StoreAppDBEntitiesEntities2();
            var selectedItem = Database.Item.ToList().Find(item => item.Id == id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Item, ItemModel>()
                //.ForMember(categoryMember => categoryMember.Category.Category,
                //m => m.MapFrom(member => member.ItemCategory.Item))
                );
            var mapper = config.CreateMapper();

            ItemModel dto = mapper.Map<ItemModel>(selectedItem);

            return View(dto);
        }

        /// <summary>
        /// More details.
        /// </summary>
        /// <returns>List of items view.</returns>
        public ActionResult MoreDetails()
        {
            StoreAppDBEntitiesEntities2 Database = new StoreAppDBEntitiesEntities2();

            List<ItemModel> modelList = new List<ItemModel>();
            List<Item> entityList = Database.Item.ToList();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Item, ItemModel>());
            var mapper = config.CreateMapper();

            List<ItemModel> dto =  mapper.Map<List<Item>, List<ItemModel>>(entityList);

            Database.SaveChanges();               


            return View(dto);
        }
    }
}