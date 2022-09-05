using System.Net.Http;
using AngloAmerican.Account.Services.Definitions.IRepository;
using Newtonsoft.Json;

namespace AngloAmerican.Account.Services
{
    public class AddressService : IAddressRepository
    {

        /* TODO
            - Improve the usage of HttpClient in GetAddress method
         */
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string GetAddress()
        {
            var response = _httpClient.GetAsync("");
            var content = response.Result.Content;
            var adr = content.ReadAsStringAsync().Result;
            var address = GetCityAndPostCode(adr);

            return address;
        }

        private string GetCityAndPostCode(string json)
        {
            dynamic jsonObject = JsonConvert.DeserializeObject<dynamic>(json);
            dynamic city = jsonObject.results[0].location.city;
            dynamic postcode = jsonObject.results[0].location.postcode;

            var address = $"{city.ToString()} {postcode.ToString()}";

            return address;
        }
    }
}
