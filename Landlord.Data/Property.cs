﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Landlord.Data
{
    public class Property
    {
        [Key]
        [Display(Name = "Property ID")]
        public int PropertyId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Display(Name = "Apartment #")]
        public int ApartmentNumber { get; set; }

        public int? TenantId { get; set; }
        public Tenant Tenant { get; set; }

        [Required]
        [Display(Name = "Monthly Rent")]
        public decimal Rent { get; set; }
        
        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public DateTimeOffset DateClaimed { get; set; }
    }
}
