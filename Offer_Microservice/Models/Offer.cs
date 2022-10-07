using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Offer_Microservice.Models
{
    public class Offer
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [IgnoreDataMember]
        public int OfferId { get; set; }
        [Required]
        public string OfferName { get; set; }
        [Required]
        [DefaultValue(false)]
        public  bool EngagedOrNot { get; set; }
        [Required]
        public DateTime OpenedDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int? EngagedBy { get; set; }
        public int? Likes { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
