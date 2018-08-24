using Landlord.Data;
using Landlord.Models;
using Landlord.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Landlord.WebMVC.Controllers
{
    public class TenantController : Controller
    {
        // GET: Property
        [Authorize]
        public ActionResult Index()
        {
            TenantService service = CreateTenantService();
            var model = service.GetTenants();

            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            TenantService svc = CreateTenantService();
            return View(svc.GetTenantById(id));
        }

        public ActionResult Details(int id)
        {
            TenantService svc = CreateTenantService();
            Tenant toView = svc.GetTenantById(id);

            return View(toView);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TenantCreate model)
        {
            TenantService svc = CreateTenantService();
            svc.CreateTenant(model);

            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TenantService svc = CreateTenantService();
            svc.DeleteTenant(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            TenantService svc = CreateTenantService();
            Tenant toEdit = svc.GetTenantById(id);

            return View(toEdit);
        }

        [HttpPost]
        public ActionResult Edit(Tenant toEdit)
        {
            TenantService svc = CreateTenantService();
            svc.UpdateTenant(toEdit);
            return RedirectToAction("Index");
        }

        [Authorize]
        private TenantService CreateTenantService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new TenantService(userId);
        }
    }
}