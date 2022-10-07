using Offer_Microservice.Data;
using Offer_Microservice.DContext;
using Offer_Microservice.Models;
using Offer_Microservice.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Offer_Microservice.Services
{
    public class OfferService : IOfferService
    {
        private readonly ApiDbContext _apiDbContext;

        private readonly IOfferProvider _offerProvider;

        public OfferService(ApiDbContext apiDbContext, IOfferProvider offerProvider)
        {
            this._apiDbContext = apiDbContext;
            this._offerProvider = offerProvider;
        }

        public string addLike(Like like)
        {
            if (like == null)
                return null;
            if(like.TimeStamp==null)
            {
                like.TimeStamp = DateTime.Now;
            }
            _apiDbContext.Likes.Add(like);
            Offer offer=_apiDbContext.Offers.SingleOrDefault(x => x.OfferId == like.OfferId);
            offer.Likes = offer.Likes + 1;
            _apiDbContext.Offers.Update(offer);
            _apiDbContext.SaveChanges();

            return "Like added";



        }

        public string addOffer(int empid, Offer offer)
        {
            offer.OpenedDate = DateTime.Now;
            offer.Likes = 0;
            offer.EngagedBy = 0;
            offer.EngagedOrNot = false;
            _apiDbContext.Offers.Add(offer);
            int a=_apiDbContext.SaveChanges();
            if (a == 1)
            {
                var mylist = _apiDbContext.Offers.ToList();
                int ind = mylist.IndexOf(offer);
                Offer obj = mylist[ind];
                _apiDbContext.Employee_Offers.Add(new Employee_Offers() { OfferId = obj.OfferId, EmployeeId = empid });
                _apiDbContext.SaveChanges();
                return "Offer Added Successfully";
            }
            return null;


        }

        public string editOffer(int id, Offer offer)
        {

            //offer.OfferId = id;

            Offer off = _apiDbContext.Offers.SingleOrDefault(x => x.OfferId == id);

            
            //off.Likes = offer.Likes;
            //off.ClosedDate = offer.ClosedDate;
            //off.EngagedBy = offer.EngagedBy;
            //off.EngagedOrNot = offer.EngagedOrNot;
            //off.OpenedDate = offer.OpenedDate;

            off.OfferName = offer.OfferName;
            off.Price = offer.Price;
            off.CategoryId = offer.CategoryId;

            _apiDbContext.Offers.Update(off);
            //_apiDbContext.Offers.Update(offer);

            

            int a = _apiDbContext.SaveChanges();
            if (a == 1)
            {
                return "Successfully updated";
            }
            return null;

        }

        public Employee engageOffer(Offer offer,int empid)
        {
            offer.ClosedDate = DateTime.Now;
            offer.EngagedOrNot = true;
            offer.EngagedBy = empid;
            string str;
            _apiDbContext.Offers.Update(offer);
            _apiDbContext.SaveChanges();
            if (offer.EngagedOrNot)
                str="Engaged Successfully";
            else
                str=null;
            var employeeoffer=_apiDbContext.Employee_Offers.SingleOrDefault(x => x.OfferId == offer.OfferId);

            var employee=_offerProvider.GetEmployee(employeeoffer.EmployeeId);
            if (str != null)
                return employee;
            else
                return null;

        }

        public IEnumerable<Offer> getOfferByCategory(string val)
        {
            Offer_Category offer_Category = _apiDbContext.Offer_Categories.SingleOrDefault(x => x.CategoryName == val);


            List < Offer > offers = (from temp in _apiDbContext.Offers where temp.CategoryId == offer_Category.CategoryId select temp).ToList();
            return offers;

           
        }

        public Offer GetOfferById(int id)
        {
            Offer offer = _apiDbContext.Offers.SingleOrDefault(x => x.OfferId == id);
            return offer;
        }

        public IEnumerable<Offer> getOfferByPostedDate(DateTime postdate)
        {
            List<Offer> offers = (from temp in _apiDbContext.Offers where temp.OpenedDate >= postdate.Date && temp.OpenedDate <= postdate.Date.AddDays(1) select temp).ToList();
            return offers;       
        }

        public IEnumerable<Offer> getOfferByTopLikes()
        {
            
            List<Offer> offers = (from temp in _apiDbContext.Offers orderby temp.Likes descending select temp).Take(3).ToList();
            return offers;        
        }
    }
}
