using Examples.Vocabulary.CustomRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Examples.Vocabulary
{
    [TestClass]
    public class DiscountRulesUnitTest
    {
        [TestMethod]
        public void TotalIsTooSmallForDiscount()
        {
            //Arrange
            var order = new Order()
            {
                CustomerName = "The Unit",
                Total = 100,
                DiscountPercent = 0.1
            };
            var rule = new DiscountLimitRule(order);

            // Act
            var result = rule.Check();

            //Assert
            Assert.AreEqual(result.IsBroken, true);


        }

        [TestMethod]
        public void SundaySalesDoNotGetDiscounts()
        {
            //Arrange
            var order = new Order()
            {
                CustomerName = "The Unit",
                Total = 100,
                DiscountPercent = 0.1,
                OrderDate = System.DateTime.Parse("2017-03-05")
            };
            var rule = new DiscountsDoNotApplyOnSundayRule(order);

            // Act
            var result = rule.Check();

            //Assert
            Assert.AreEqual(result.IsBroken, true);


        }
    }
}
