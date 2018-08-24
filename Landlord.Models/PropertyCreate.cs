using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landlord.Models
{
    public class PropertyCreate
    {

        //You should put more models in here, maybe some Swedish or Brazillian models?
        [Key]
        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Display(Name = "Apartment #")]
        public int ApartmentNumber { get; set; }

        public TenantList Tenant { get; set; }

        [Display(Name = "Monthy Rent")]
        [Required]
        public decimal Rent { get; set; }
    }
}