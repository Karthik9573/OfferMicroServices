using NUnit.Framework;
using NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Offer_Microservice.Services;
using Offer_Microservice.Controllers;
using Offer_Microservice.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Offer_Microservice.Data;

namespace Offer_Tests
{
    [TestFixture]
    class OfferTests
    {
        OfferController controller;
        Mock<IOfferService> mockservice;
        [SetUp]
        public void Setup()
        {
            mockservice = new Mock<IOfferService>();
            controller = new OfferController(mockservice.Object);
        }

        [Test]
        public void valid_getoffersbyid()
        {
            var offerId = 8;
            Offer offer = new Offer { OfferId = 8 };
            mockservice.Setup(s => s.GetOfferById(offerId)).Returns(offer);
            
            var result = controller.GetOfferDetailsById(offerId);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okresult.StatusCode);
        }


        [Test]
        public void Bad_getoffersbyid()
        {
            var offerId = 8;
            Offer offer = null;
            mockservice.Setup(s => s.GetOfferById(offerId)).Returns(offer);

            var result = controller.GetOfferDetailsById(offerId);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(404, okresult.StatusCode);
        }

        [Test]
        public void valid_getOfferbyCategory()
        {
            var category = "cars";
            var offer = new List<Offer>() { new Offer(){ CategoryId = 5} };    
            mockservice.Setup(s => s.getOfferByCategory(category)).Returns(offer);

            var result = controller.getOfferByCategory(category);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okresult.StatusCode);
        }

        [Test]
        public void Bad_getOfferbyCategory()
        {
            var category = "cars goats";
            List<Offer> offers = null;
            mockservice.Setup(s => s.getOfferByCategory(category)).Returns(offers);

            var result = controller.getOfferByCategory(category);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(400, okresult.StatusCode);
        }


        [Test]
        public void valid_getOfferByTopLikes()
        {
            
            var offer = new List<Offer>() { new Offer() { CategoryId = 5 } };
            mockservice.Setup(s => s.getOfferByTopLikes()).Returns(offer);

            var result = controller.getOfferByTopLikes();
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okresult.StatusCode);
        }

        [Test]
        public void Bad_getOfferByTopLikes()
        {
            
            List<Offer> offers = null;
            mockservice.Setup(s => s.getOfferByTopLikes()).Returns(offers);

            var result = controller.getOfferByTopLikes();
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(404, okresult.StatusCode);
        }

        [Test]
        public void valid_getOfferByPostedDate()
        {
            DateTime dateTime=DateTime.Parse("2021-10-22");
            var offer = new List<Offer>() { new Offer() { OpenedDate=dateTime} };
            mockservice.Setup(s => s.getOfferByPostedDate(dateTime)).Returns(offer);

            var result = controller.getOfferByPostedDate(dateTime);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okresult.StatusCode);
        }

        [Test]
        public void Bad_getOfferByPostedDate()
        {
            DateTime dateTime = DateTime.Parse("1999-10-22");
            List<Offer> offers = null;
            mockservice.Setup(s => s.getOfferByPostedDate(dateTime)).Returns(offers);

            var result = controller.getOfferByPostedDate(dateTime);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(404, okresult.StatusCode);
        }

        [Test]
        public void valid_Addlike()
        {
            var Empid = 113;
            var offerId = 5;
            Like like = new Like() { OfferId = offerId, EmployeeId = Empid };
            string status = "";
            
            mockservice.Setup(s => s.addLike(like)).Returns(status);

            var result = controller.Addlike(like);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okresult.StatusCode);
        }


        [Test]
        public void Bad_Addlike()
        {
            var Empid = 113;
            
            Like like = new Like() {EmployeeId = Empid };
            string status = null;

            mockservice.Setup(s => s.addLike(like)).Returns(status);

            var result = controller.Addlike(like);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(400, okresult.StatusCode);
        }

        [Test]
        public void valid_engageOffer()
        {
            var Empid = 113;
            var offerId = 7;
            Offer offer = new Offer { OfferId = 7};
            Employee employee = new Employee() {  Points=0};

            mockservice.Setup(s => s.GetOfferById(offerId)).Returns(offer);
            mockservice.Setup(s => s.engageOffer(offer,Empid)).Returns(employee);
            var result = controller.engageOffer(offerId,Empid);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okresult.StatusCode);
        }

        [Test]
        public void Bad_engageOffer()
        {
            var Empid = 113;
            var offerId = 7;
            Offer offer = null;
            Employee employee = new Employee() { Points = 0 };

            mockservice.Setup(s => s.GetOfferById(offerId)).Returns(offer);
            
            var result = controller.engageOffer(offerId, Empid);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(404, okresult.StatusCode);
        }

        [Test]
        public void valid_AddOffer()
        {
            var Empid = 113;
            
            Offer offer = new Offer {OfferName="fridge", CategoryId=3, Price=1500 };

            string status = "";
            
            mockservice.Setup(s => s.addOffer(Empid,offer)).Returns(status);
            var result = controller.addOffer(Empid,offer);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okresult.StatusCode);
        }


        [Test]
        public void Bad_AddOffer()
        {
            var Empid = 113;

            Offer offer = null;

            string status = null;

            mockservice.Setup(s => s.addOffer(Empid, offer)).Returns(status);
            var result = controller.addOffer(Empid, offer);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(400, okresult.StatusCode);
        }

        [Test]
        public void valid_EditOffer()
        {
            var offerid = 7;

            Offer offer = new Offer { OfferId = 7,  Price = 1500 };

            string status = "";

            mockservice.Setup(s => s.editOffer(offerid, offer)).Returns(status);
            var result = controller.editOffer(offerid, offer);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okresult.StatusCode);
        }

        [Test]
        public void Bad_EditOffer()
        {
            var offerid = 7;

            Offer offer = null;
            

            string status = null;

            mockservice.Setup(s => s.editOffer(offerid, offer)).Returns(status);
            var result = controller.editOffer(offerid, offer);
            var okresult = (IStatusCodeActionResult)result;
            Assert.AreEqual(400, okresult.StatusCode);
        }
    }
}
