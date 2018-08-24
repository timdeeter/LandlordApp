using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landlord.Models
{
    public class TenantList
    {
        [Key]
        [Display(Name = "Tenant ID")]
        public int TenantId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}