namespace BusinessDomain
{
    /// <summary>
    /// The Product class represent each product available for purchase, with the name and price of the product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Constructor for Product, setting the product properties to input values
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        /// <summary>
        /// Fields?
        /// </summary>
        private string name;
        private double price;

        /// <summary>
        /// Get and Set properties for name with encapsulation, securing that the name is over 0 and under 50 letters long
        /// </summary>
        public string Name
        {
            get 
            {
                return name;
            }
            set 
            {
                if (value.Length < 0 || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException("Navnet må kun have mellem 1 og 50 karaktere");
                }
                name = value;
            }
        }

        /// <summary>
        /// Get and set properties on Price with encapsulation, securing that the price can not be negative
        /// </summary>
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Prisen må ikke være i minus");
                }
                price = value;
            }
        } 
    }
}
