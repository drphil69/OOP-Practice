using System.Net.Mail;

namespace BusinessDomain
{
    /// <summary>
    /// The class Customer represents a customer, with a name, mail, and a basket
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Method that returns true if the input mail is valid
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
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
        /// Constructor for Customer, setting it's properties to given inputs
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mail"></param>
        public Customer(string name, string mail, Basket basket)
        {
            Name = name;
            Mail = mail;
            Basket = basket;
        }

        /// <summary>
        /// The fields of the Customer class, containing the state of the objects properties
        /// </summary>
        private string name;
        private string mail;
        public Basket Basket { get; private set; }

        /// <summary>
        /// Get and set properties for name with encapsulation, securing it does not contain numbers
        /// </summary>
        public string Name 
        {
            get 
            {
                return name;
            }
            set 
            {
                if (value.All(char.IsNumber))
                {
                    throw new ArgumentException("Navnet må ikke indeholde tal");
                }
                name = value;
            }
        }

        /// <summary>
        /// Get and set for properties for mail with encapsulation, securing that the mail is valid by using the IsEmailValid method
        /// </summary>
        public string Mail
        {
            get
            {
                return mail;
            }
            set 
            {
                if (!(IsEmailValid(value)))
                {
                    throw new ArgumentException("Ugyldig mail");
                }
                mail = value;
            }
        }
    }
}