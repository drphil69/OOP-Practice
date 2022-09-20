using Newtonsoft.Json.Linq;
using System.Net.Mail;

namespace Tests
{
    public class CustomerTest
    {
        //Used later in the test
        private bool IsEmailValid(string email)
        {
            var valid = true;
            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }
            return valid;
        }

        /// <summary>
        /// Tests if customer has invalid start state, this test should fail
        /// </summary>
        [Fact]
        public void CustomerWithInvalidStartState()
        {
            // Arrange & Act:
            Customer c = new("007", "min mail");

            // Assert:
            Assert.False(c.Name.All(char.IsNumber));
            Assert.True(IsEmailValid(c.Mail));
        }

        /// <summary>
        /// Tests if the customer can be mutated to invalid state, this should fail
        /// </summary>
        [Fact]
        public void CustomerWithInvalidMutation()
        {
            // Arrange:
            Customer c = new("James Bond", "james@bond.net");

            //Act
            c.Name = "007";
            c.Mail = "min mail";

            // Assert:
            Assert.False(c.Name.All(char.IsNumber));
            Assert.True(IsEmailValid(c.Mail));
        }
    }
}