using System;
using Landlord.Data;
using Landlord.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;

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
            TenantService tenantService = new TenantService(_ownerId);
            Result LocationData = GetLocationData(model.Address);
            var entity =
                new Property
                {
                    OwnerId = _ownerId,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    ApartmentNumber = model.ApartmentNumber,
                    Rent = model.Rent,
                    TenantId = model.TenantId,
                    Longitude = LocationData.geometry.location.lng.ToString(),
                    Latitude = LocationData.geometry.location.lat.ToString(),
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
            TenantService tenantService = new TenantService(_ownerId);

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
                                    DateClaimed = e.DateClaimed,
                                    Longitude = e.Longitude,
                                    Latitude = e.Latitude,
                                    TenantName = (e.Tenant.FirstName + " " + e.Tenant.LastName)
                                }
                        ).ToList();
                return query;
            }
        }
        private static Result _data = new Result();
        private static string _address;
        public Result GetLocationData(string address)
        {
            _address = address;
            string LocationData = getLocationData();
            Result LocationObject = DeserializeLocationData(LocationData);
            return LocationObject;

            //var locationData = _data;
            //eturn locationData;
        }

        public Result DeserializeLocationData(string SerializedData)
        {
            var LocationData = JsonConvert.DeserializeObject<RootObject>(SerializedData);
            return LocationData.results[LocationData.results.Count - 1];
        }

        private static String getLocationData()
        {
            using (var client = new HttpClient())
            {
                string address = _address;
                string requestUrl = "https://maps.googleapis.com/maps/api/geocode/json?address=" + address.Replace(' ', '+') + "&key=AIzaSyAZZA66wU6vz39Jc2WY5uiD4eWygYNg2RM";


                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
                webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }


                //HttpResponseMessage response = await client.GetAsync(request);

                //response.EnsureSuccessStatusCode();

                //using (HttpContent content = response.Content)
                //{
                //    string responseBody = await response.Content.ReadAsStringAsync();

                //    return responseBody;
                //}
            }
        }

        public Property GetPropertyById(int id)
        {
            using (var ctx = new Landlord.Data.ApplicationDbContext())
            {
                Property toRemove = ctx.Properties.Find(id);
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
            Result LocationData = GetLocationData(toUpdate.Address);
            using (var ctx = new Landlord.Data.ApplicationDbContext())
            {
                toUpdate.Latitude = LocationData.geometry.location.lat.ToString();
                toUpdate.Longitude = LocationData.geometry.location.lng.ToString();
                ctx.Entry(toUpdate).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }



    }
}