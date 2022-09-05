using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace AngloAmerican.Account.Tests.Intergration
{
    public class Test
    {
        [Fact]
        public void GetAddress()
        {
            var apiClient = new HttpClient();

            var apiResponse = apiClient.GetAsync($"https://randomuser.me/api/?nat=gb").Result;

            Assert.True(apiResponse.IsSuccessStatusCode);
        }
    }
}
