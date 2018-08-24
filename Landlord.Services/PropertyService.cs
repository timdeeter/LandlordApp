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
    public class PropertyService
    {

        private readonly Guid _ownerId;
        public PropertyService(Guid owner)
        {
            _ownerId = owner;
        }

        public bool CreateProperty(PropertyCreate model)
        {
            var entity =
                new Property
                {
                    OwnerId = _ownerId,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    ApartmentNumber = model.ApartmentNumber,
                    Rent = model.Rent,
                    DateClaimed = DateTimeOffset.Now
                };
            using (var ctx = new Landlord.Data.ApplicationDbContext())
            {
                ctx.Properties.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public List<PropertyList> GetProperties()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = 
                    ctx
                        .Properties
                        .Where(e => e.OwnerId == _ownerId)
                        .Select(
                            e =>
                                new PropertyList
                                {
                                    PropertyId = e.PropertyId,
                                    Address = e.Address,
                                    City = e.City,
                                    State = e.State,
                                    DateClaimed = e.DateClaimed
                                }
                        ).ToList();
                return query;
            }
        }

        public Property GetPropertyById(int id)
        {
            using (var ctx = new Landlord.Data.ApplicationDbContext())
            {
                Property toRemove = ctx.Properties.Find(id);
                //ctx.Properties.Remove(toRemove);
                return toRemove;
            }
        }

        public void DeleteProperty(int id)
        {
            using (var ctx = new Landlord.Data.ApplicationDbContext())
            {
                Property toRemove = ctx.Properties.Find(id);
                ctx.Properties.Remove(toRemove);
                ctx.SaveChanges();
            }
        }

        public void UpdateProperty(Property toUpdate)
        {
            using (var ctx = new Landlord.Data.ApplicationDbContext())
            {
                ctx.Entry(toUpdate).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

    }
}