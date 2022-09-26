namespace BusinessDomain
{
    /// <summary>
    /// The basket class represents each customers basket, which contains a total price and a list of products in it.
    /// </summary>
    public class Basket
    {
        #region Constructors
        /// <summary>
        /// Basket's Constructors, sets Basket properties to given inputs
        /// </summary>
        /// <param name="totalPrice"></param>
        /// <param name="products"></param>
        public Basket(double totalPrice, List<Product> products)
        {
            Products = products;
            TotalPrice = TotalPrice;
        }

        public Basket(double totalPrice)
        {
            Products = new();
            TotalPrice = TotalPrice;
        }
        #endregion

        #region Fields
        /// <summary>
        /// The fields of the Basket class, containing the state of the objects properties
        /// </summary>
        private double totalPrice;
        private List<Product> products;
        #endregion

        #region Properties
        /// <summary>
        /// Get and set properties on TotalPrice with encapsulation, securing that TotalPrice always is more than 0
        /// </summary>
        public double TotalPrice
        {
            get => totalPrice;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Totalprisen kan ikke være i minus");
                }
                totalPrice = value;
            }
        }

        /// <summary>
        /// Get and set properties on Products with encapsulation, securing that Products is not null
        /// </summary>
        public List<Product> Products
        {
            get => products;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Produkter må ikke være null");
                }
                products = value;
            }
        } 
        #endregion
    }
}