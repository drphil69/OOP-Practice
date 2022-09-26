using System.Net.Mail;
using System.Runtime.Serialization;

namespace BusinessDomain
{
    /// <summary>
    /// The class Customer represents a customer, with a name, mail, and a basket
    /// </summary>
    public class Customer
    {
        #region Constructors
        /// <summary>
        /// Constructors for Customer, setting it's properties to given inputs
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mail"></param>
        public Customer(string name, string mail):this(name, mail, CustomerTypes.Basis, new Basket(0, new()))
        {
        }

        public Customer(string name, string mail, CustomerTypes customertype, Basket basket)
        {
            Name = name;
            Mail = mail;
            CustomerType = new(customertype);
            Basket = basket;
        } 
        #endregion

        #region Fields
        /// <summary>
        /// The fields of the Customer class, containing the state of the objects properties
        /// </summary>
        private string name;
        private string mail;
        private CustomerType customertype;
        private Basket basket;
        #endregion

        #region Properties
        /// <summary>
        /// Get and set properties for name with encapsulation, securing it does not contain numbers
        /// </summary>
        public string Name
        {
            get => name;
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
            get => mail;
            set
            {
                if (!(IsEmailValid(value)))
                {
                    throw new ArgumentException("Ugyldig mail");
                }
                mail = value;
            }
        }

        /// <summary>
        /// Get and set properties for CustomerType with encapsulation, secruing that CustomerType is not null
        /// </summary>
        public CustomerType CustomerType 
        {
            get => customertype;
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException("CustomerType må ikke være null");
                }
                customertype = value;
            }
        }

        /// <summary>
        /// Get and set properties for Basket with encapsulation, secruing that Basket is not null
        /// </summary>
        public Basket Basket
        {
            get => basket;
            private set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Din kurv kan ikke være null");
                }
                basket = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that returns true if the input mail is valid
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true or false, depending if it's an correct email address</returns>
        public bool IsEmailValid(string email)
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
        #endregion
    }
}