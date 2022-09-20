using System.Net.Mail;

namespace Tests
{
    public class BasketTest
    {
        /// <summary>
        /// Tests if basket has invalid start state, this test should fail
        /// </summary>
        [Fact]
        public void BasketWithInvalidStartState()
        {
            // Arrange & Act:
            Basket b = new(-1, null);

            // Assert:
            Assert.True(b.TotalPrice >= 0);
            Assert.NotNull(b.Products);
        }

        /// <summary>
        /// Tests if the basket can be mutated to invalid state, this should fail
        /// </summary>
        [Fact]
        public void BasketWithInvalidMutation()
        {
            // Arrange:
            Basket b = new(210, new());

            //Act
            b.TotalPrice = -1;
            b.Products = null;

            // Assert:
            Assert.True(b.TotalPrice >= 0);
            Assert.NotNull(b.Products);
        }
    }
}