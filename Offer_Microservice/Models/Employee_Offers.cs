using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Offer_Microservice.Models
{
    public class Employee_Offers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OfferId { get; set; }
        public int EmployeeId { get; set; }
    }
}
