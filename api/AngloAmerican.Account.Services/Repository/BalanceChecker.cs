using System;
using System.Collections.Generic;

namespace AngloAmerican.Account.Services
{
    /* TODO
        - Refactor the class and add Unit Tests
    */
    public class BalanceChecker
    {
        Notification notification = new Notification();
        ExternalApi eA = new ExternalApi();

        //Abstract the Process Method
        public bool Process(int amount, string lastName)
        {
            var emailTitle = "";
            var emailBody = "<p>Body placeholder<p>";
            var currentDate = DateTime.Now.Day;

            if (currentDate < 15)
            {
                emailTitle = "<h1>Info about days till Middle of the month</h1>";
            }
            else
            {
                emailTitle = "<h1>Info about days till End of the month</h1>";
            }

            
            var message = emailTitle + "\n" + emailBody;

            if (amount < 10000)
            {
                notification.SendEmail(emailTitle, emailBody);
            }
            if (amount > 10000)
            {
                notification.SendMessage(message);
                return eA.CheckAccountBalance(amount, lastName);
            }

            return true;
        }
    }

    public class Notification
    {
        public void SendEmail(string title, string body)
        {
            // it sends an email
        }

        public void SendMessage(string message)
        {
            // it sends a message
        }
    }


    // TODO: Improve and make the code more readable.
    public class ExternalApi
    {
        private List<string> lastNames = new List<string> {"Rene", "Kirk", "Escarole"};

        // returns true if balance is valid
        public bool CheckAccountBalance(int amount, string lastName)
        {
            // if the person is in the list and balance is greater than 10,000 return false
            foreach (var lName in lastNames)
            {
                if (lName == lastName)
                {
                    if (amount > 10000)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            return true;
        }
    }
}