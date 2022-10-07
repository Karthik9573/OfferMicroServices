using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Offer_Microservice.Models
{
    public class Like
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [IgnoreDataMember]
        public int LikeId { get; set; }
        [Required]
        public int EmployeeId{ get; set; }

        [Required]
        public int OfferId { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
