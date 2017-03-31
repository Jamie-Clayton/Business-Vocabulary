using Business.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Validation
{
    public class Order
    {
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public double Total { get; set; }
        public double DiscountPercent { get; set; }
        private IEnumerable<ValidationFailure> failures;

        public bool IsValid
        {
            get
            {
                var validations = new OrderDiscountRule();
                failures = validations.Validate(this);
                return failures.Count() == 1;
            }
        }
        
        public void ApplyOrderDiscount(double total, double discountPercentToApplyToTotal)
        {
            this.Total = total;
            this.DiscountPercent = discountPercentToApplyToTotal;
            //  Apply a parameter validation business rule, to restrict inappropriate discounts.

        }

        public void Create(string customerName, DateTime date)
        {
            this.CustomerName = customerName;
            this.OrderDate = date;
        }

        public void Save()
        {
            //  Before you save a record, check it meets all the busines rules.
            if (this.IsValid)
            {
                // 
            }
            else
            {
                Console.WriteLine(failures.SelectMany(f => f.ErrorMessage));
            }
        }
    }
}
