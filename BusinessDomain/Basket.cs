namespace BusinessDomain
{
    /// <summary>
    /// The basket class represents each customers basket, which contains a total price and a list of products in it.
    /// </summary>
    public class Basket
    {
        /// <summary>
        /// Basket's Constructor, sets Basket properties to given inputs
        /// </summary>
        /// <param name="totalPrice"></param>
        /// <param name="products"></param>
        public Basket(double totalPrice, List<Product> products)
        {
            Products = products;
            TotalPrice = TotalPrice;
        }

        /// <summary>
        /// Fields?
        /// </summary>
        private double totalPrice;
        private List<Product> products;

        /// <summary>
        /// Get and set properties on TotalPrice with encapsulation, securing that TotalPrice always is more than 0
        /// </summary>
        public double TotalPrice
        {
            get 
            {
                return totalPrice;
            }
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
            get 
            {
                return products;    
            }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Produkter må ikke være null");
                }
                products = value;
            }
        }
    }
}
