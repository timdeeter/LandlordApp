using System;
using Landlord.Data;
using Landlord.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace Landlord.Services
{
    public class TenantService
    {

        private readonly Guid _ownerId;
        public TenantService(Guid owner)
        {
            _ownerId = owner;
        }

        public bool CreateTenant(TenantCreate model)
        {
            var entity =
                new Tenant
                {
                    OwnerId = _ownerId,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
            using (var ctx = new Landlord.Data.ApplicationDbContext())
            {
                ctx.Tenants.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public List<TenantList> GetTenants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tenants
                        .Where(e => e.OwnerId == _ownerId)
                        .Select(
                            e =>
                                new
                                {
                                    TenantId = e.TenantId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                }
                        ).ToList()
                        .Select(c => new Landlord.Models.TenantList
                        {
                            TenantId = c.TenantId,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                        }).ToList();
                return query;
            }
        }

        public Tenant GetTenantById(int id)
        {
            using (var ctx = new Landlord.Data.ApplicationDbContext())
            {
                Tenant toRemove = ctx.Tenants.Find(id);
                //ctx.Properties.Remove(toRemove);
                return toRemove;
            }
        }

        public void DeleteTenant(int id)
        {
            using (var ctx = new Landlord.Data.ApplicationDbContext())
            {
                Tenant toRemove = ctx.Tenants.Find(id);
                ctx.Tenants.Remove(toRemove);
                ctx.SaveChanges();
            }
        }

        public void UpdateTenant(Tenant toUpdate)
        {
            using (var ctx = new Landlord.Data.ApplicationDbContext())
            {
                ctx.Entry(toUpdate).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

    }
}