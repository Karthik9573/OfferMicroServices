using Offer_Microservice.Data;
using Offer_Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Offer_Microservice.Services
{
    public interface IOfferService
    {
        public Offer GetOfferById(int id);
        public IEnumerable<Offer> getOfferByCategory(string val);
        public IEnumerable<Offer> getOfferByTopLikes();
        public IEnumerable<Offer> getOfferByPostedDate(DateTime postdate);
        public Employee engageOffer(Offer offer,int empid);
        public string addOffer(int empid, Offer offer);
        string addLike(Like like);
        public string editOffer(int id, Offer offer);
    }
}
