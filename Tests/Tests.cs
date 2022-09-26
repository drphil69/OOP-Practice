namespace Tests
{
    public class Tests
    {
        #region Customer Tests
        /// <summary>
        /// Tests if there is an exception when creating a Customer with wrong statements
        /// </summary>
        [Fact]
        public void ThrowsExceptionOnWrongCustomerProperties()
        {
            // Arrange:
            Func<Customer> call;

            // Act:
            call = () => new Customer("007", ",", CustomerTypes.Basis, null);


            // Assert:
            Assert.Throws<ArgumentException>(call);
        }

        /// <summary>
        /// Tests if its possible to create a Customer with correct statements
        /// </summary>
        [Fact]
        public void CorrectInitializationOnNewCustomer()
        {
            //Arrange:
            Customer c1;
            Customer c2;

            //Act:
            c1 = new("Jens Andersen", "Jens@andersen.dk");
            c2 = new("Jesper Audisen", "Jema@aspit.dk", CustomerTypes.Basis, new(0));

            //Assert:
            Assert.NotNull(c1);
            Assert.NotNull(c2);
            Assert.NotNull(c1.Basket);
            Assert.NotNull(c2.Basket);
        }

        //LAV MUTATION TEST
        #endregion

        #region Product Tests
        /// <summary>
        /// Tests if there is an exception when creating a Product with wrong statements
        /// </summary>
        [Fact]
        public void ThrowsExceptionOnWrongProductProperties()
        {
            // Arrange:
            Func<Product> call;

            // Act:
            call = () => new Product("ggggggggggggggggggggggggggggggggggggggggggggggggggg", -5);


            // Assert:
            Assert.Throws<ArgumentOutOfRangeException>(call);
        }

        /// <summary>
        /// Tests if its possible to create a Product with correct statements
        /// </summary>
        [Fact]
        public void CorrectInitializationOnNewProduct()
        {
            //Arrange:
            Product p;

            //Act:
            p = new("Netflix", 10);

            //Assert:
            Assert.NotNull(p);
        }

        [Fact]
        public void ThrowsExceptionOnInvalidProductMutation()
        {
            //Arrange
            Product p = new("Peanuts", 12);
            Func<string> call;

            //Act
            call = () => p.Name = "abcdefghijklmnopqrstuvwxyzæøåabcdefghijklmnopqrstuvwxyzæøå";

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(call);
        }
        #endregion

        #region Basket Tests
        /// <summary>
        /// Tests if there is an exception when creating a Basket with wrong statements
        /// </summary>
        [Fact]
        public void ThrowsExceptionOnWrongBasketProperties()
        {
            // Arrange:
            Func<Basket> call;

            // Act:
            call = () => new Basket(-1, null);


            // Assert:
            Assert.Throws<ArgumentNullException>(call);
        }

        /// <summary>
        /// Tests if its possible to create a Bakset with correct statements
        /// </summary>
        [Fact]
        public void CorrectInitializationOnNewBasket()
        {
            //Arrange:
            Basket b1;
            Basket b2;

            List<Product> testproducts = new();
            Product p1 = new("Pro1", 10);
            Product p2 = new("Pro2", 10);
            testproducts.Add(p1);
            testproducts.Add(p2);

            //Act:
            b1 = new(10);
            b2 = new(10, testproducts);

            //Assert:
            Assert.NotNull(b1);
            Assert.NotNull(b2);
            Assert.NotNull(b1.Products);
            Assert.NotNull(b2.Products);
        }

        [Fact]
        public void ThrowsExceptionOnInvalidBasketMutation()
        {
            //Arrange
            Basket b = new(10);
            Func<object> call;

            //Act
            call = () => b.TotalPrice = -2;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(call);
        }
        #endregion
    }
}