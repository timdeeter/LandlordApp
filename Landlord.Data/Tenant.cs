using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landlord.Data
{
    public class Tenant
    {
        [Key]
        [Display(Name = "Tenant ID")]
        public int TenantId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTimeOffset DateMovedIn { get; set; }
    }
}