using AngloAmerican.Account.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace AngloAmerican.Account.Tests.Intergration
{
    public class Test
    {
        //GetAddress API Test
        [Fact]
        public void GetAddress()
        {
            var apiClient = new HttpClient();

            var apiResponse = apiClient.GetAsync($"https://randomuser.me/api/?nat=gb").Result;

            Assert.True(apiResponse.IsSuccessStatusCode);
        }

        //BalanceChecker test
        [Fact]
        public void ProcessBalanceTrue()
        {
            //Arrange
            BalanceChecker bc = new BalanceChecker();

            //Act
            bool response = bc.Process(5000, "Jason");

            //Assert True since amount < 10000
            Assert.True(response);

        }

        //BalanceChecker test
        [Fact]
        public void ProcessBalanceFalse()
        {
            //Arrange
            BalanceChecker bc = new BalanceChecker();

            //Act
            bool response = bc.Process(10001, "Rene");

            //Assert False since amount > 10000 and Rene is in list
            Assert.False(response);

        }
    }
}
