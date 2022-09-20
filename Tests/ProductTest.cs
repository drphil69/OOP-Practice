namespace Tests
{
    public class ProductTest
    {
        /// <summary>
        /// Tests if product has invalid start state, this test should fail
        /// </summary>
        [Fact]
        public void ProductWithInvalidStartState()
        {
            // Arrange & Act:
            Product p = new("gggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg", -3);

            // Assert:
            Assert.True(p.Name.Length <= 50);
            Assert.True(p.Price > 0);
        }

        /// <summary>
        /// Tests if the product can be mutated to invalid state, this should fail
        /// </summary>
        [Fact]
        public void ProductWithInvalidMutation()
        {
            // Arrange:
            Product p = new("Peanuts", 10);

            //Act
            p.Name = "LalalalasagnewuptiwuptiLalalalasagnewuptiwuptiLalalalasagnewuptiwuptiLalalalasagnewuptiwuptiLalalalasagnewuptiwupti";
            p.Price = -1;

            // Assert:
            Assert.True(p.Name.Length <= 50);
            Assert.True(p.Price > 0);
        }
    }
}