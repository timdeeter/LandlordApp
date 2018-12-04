using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landlord.Models
{
    public class PropertyList
    {
        [Key]
        public int PropertyId { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public DateTimeOffset DateClaimed { get; set; }

        public string TenantName;

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}