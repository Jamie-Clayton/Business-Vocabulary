using Business.Vocabulary;
using Examples.Vocabulary.CustomRules;
using System;
using System.Linq;

namespace Examples.Vocabulary
{
    public class Order
    {
        
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public double Total { get; set; }
        public double DiscountPercent { get; set; }

        Rules<Order> rulesChecklist = new Rules<Order>();

        public Order()
        {
            // Setup all the business rules.
            rulesChecklist.Add(new DiscountLimitRule(this));
            rulesChecklist.Add(new DiscountsDoNotApplyOnSundayRule(this));
            rulesChecklist.Add(new OrderRequiredInformationRule(this));
        }

        public void ApplyOrderDiscount(double total, double discountPercentToApplyToTotal)
        {
           
            this.Total = total;
            this.DiscountPercent = discountPercentToApplyToTotal;

            //  Apply a parameter validation business rule, to restrict inappropriate discounts.
            rulesChecklist.Check(BusinessRuleGroup.DiscountPolicy);
            if (rulesChecklist.Broken.Any())
            {
                //  warn the user of broken business rule.
                foreach(string explaination in rulesChecklist.Broken.Select(rule => rule.Description).ToList())
                {
                    Console.WriteLine(explaination);
                }
                
                //  Reset the discount for the order if the discount policy business rules fails.
                this.DiscountPercent = 0;
            }            
        }

        public void Create(string customerName, DateTime date)
        {
            this.CustomerName = customerName;
            this.OrderDate = date;
        }

        public bool Save()
        {
            //  Before you save a record, check it meets all the busines rules.
            this.rulesChecklist.Check();
            if (this.rulesChecklist.Broken.Any())
            {
                //  Warn user why they can't save record.
                
            }
            else
            {
                //  Save record
            }

            //  Let the application know if the record was saved.
            return this.rulesChecklist.Broken.Any();
        }
    }
}
