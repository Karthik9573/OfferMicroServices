using Newtonsoft.Json;
using Offer_Microservice.Data;
using Offer_Microservice.DContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Offer_Microservice.Provider
{
    public class OfferProvider : IOfferProvider
    {
        private IHttpClientFactory _httpClientFactory;
        private readonly ApiDbContext _apiDbContext;
        public OfferProvider(IHttpClientFactory httpClientFactory, ApiDbContext apiDbContext )
        {
            this._httpClientFactory = httpClientFactory;
            this._apiDbContext = apiDbContext;

        }

        public Employee GetEmployee(int empid)
        {
            Employee employee = new Employee();

            using (HttpClient httpClient = _httpClientFactory.CreateClient("employee"))
            {


                HttpResponseMessage response = httpClient.GetAsync("api/Employee/" + empid).Result;
                if (response.IsSuccessStatusCode)//200
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    employee = (JsonConvert.DeserializeObject<Employee>(result));
                }



            }
            return employee;
        }
    }
}
