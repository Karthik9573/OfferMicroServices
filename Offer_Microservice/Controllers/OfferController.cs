using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Offer_Microservice.Models;
using Offer_Microservice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Offer_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    //[Authorize]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;
        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }
        
        [AllowAnonymous]
        [HttpGet("getOfferDetailsById/{id}")]
        public IActionResult GetOfferDetailsById(int id)
        {
            var offer = _offerService.GetOfferById(id);
            if (offer == null)
                return NotFound();
            else
            {
                return Ok(offer);
            }

            
        }

        
        [HttpGet("getOfferByCategory/{val}")]
        public IActionResult getOfferByCategory(string val)
        {
            var offers = _offerService.getOfferByCategory(val);
            if (offers == null)
                return BadRequest();
            else
            {
                return Ok(offers);
            }


        }

        


        [HttpGet("getOfferByTopLikes")]
        public IActionResult getOfferByTopLikes()
        {
            var offers = _offerService.getOfferByTopLikes();
            if (offers == null)
                return NotFound();
            else
            {
                return Ok(offers);
            }

        }

        [HttpGet("getOfferByPostedDate/{postdate}")]
        public IActionResult getOfferByPostedDate([FromRoute] DateTime postdate)
        {

            var offers = _offerService.getOfferByPostedDate(postdate);
            if (offers == null)
                return NotFound();
            else
            {
                return Ok(offers);
            }

        }
        [HttpPost("AddLike")]
        public IActionResult Addlike([FromBody] Like like)
        {
            var status=_offerService.addLike(like);
            if (status != null)
                return Ok();
            else
                return BadRequest();
        }

        
        [HttpGet("engageOffer/{id}/{empid}")]
        public IActionResult engageOffer(int id, int empid)
        {
            var offer = _offerService.GetOfferById(id);
            if (offer == null)
                return NotFound();
            else
            {
                var employee= _offerService.engageOffer(offer, empid);
                return Ok(employee);
            }
        }

        
        [HttpPost("addOffer/{empid}")]
        public IActionResult addOffer([FromRoute] int empid ,[FromBody] Offer offer)
        {
            if (ModelState.IsValid)
            {
                string str = _offerService.addOffer(empid, offer);
                if (str != null)
                    return Ok(str);
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        [HttpPut("editOffer/{id}")]
        public IActionResult editOffer([FromRoute] int id, [FromBody] Offer offer)
        {
            if (ModelState.IsValid)
            {
                var str=_offerService.editOffer(id, offer);
                if (str != null)
                    return Ok(str);
                else
                    return BadRequest();

            }
            else
                return BadRequest();

        }


    }
}
