﻿using Landlord.Data;
using Landlord.Models;
using Landlord.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Landlord.WebMVC.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Property
        [Authorize]
        public ActionResult Index()
        {
            PropertyService service = CreatePropertyService();
            var model = service.GetProperties();

            return View(model);
        }

        [HttpPost]
        public JsonResult UpdateLocation(string data)
        {
            var Data = data;
            return Json("Success");
        }

        [Authorize]
        public ActionResult Create()
        {
            TenantService svc = new TenantService(Guid.Parse(User.Identity.GetUserId()));
            ViewBag.TenantId = new SelectList(svc.GetTenants(), "TenantId", "DisplayName"); //GetTenants, idk, Display Name in Dropdown
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyCreate model)
        {
            PropertyService svc = CreatePropertyService();
            if (svc.CreateProperty(model)){
                return RedirectToAction("Index");
            }
            

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            PropertyService svc = CreatePropertyService();
            return View(svc.GetPropertyById(id));
        }

        public ActionResult Details(int id)
        {
            PropertyService svc = CreatePropertyService();
            Property toView = svc.GetPropertyById(id);
            
            return View(toView);
        }

        

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyService svc = CreatePropertyService();
            svc.DeleteProperty(id);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            TenantService tenantsvc = new TenantService(Guid.Parse(User.Identity.GetUserId()));
            ViewBag.TenantId = new SelectList(tenantsvc.GetTenants(), "TenantId", "DisplayName");
            PropertyService svc = CreatePropertyService();
            Property toEdit = svc.GetPropertyById(id);

            return View(toEdit);
        }

        [HttpPost]
        public ActionResult Edit(Property toEdit)
        {
            PropertyService svc = CreatePropertyService();
            svc.UpdateProperty(toEdit);
            return RedirectToAction("Index");
        }

        [Authorize]
        private PropertyService CreatePropertyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new PropertyService(userId);
        }
    }
}