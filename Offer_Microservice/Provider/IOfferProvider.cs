using Offer_Microservice.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Offer_Microservice.Provider
{
    public interface IOfferProvider
    {
        Employee GetEmployee(int empid);
    }
}
