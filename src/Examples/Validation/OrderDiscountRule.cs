using Business.Validation;
using System;
using System.Collections.Generic;

namespace Examples.Validation
{
    class OrderDiscountRule: ValidationRule<Order>
    {

        public override IEnumerable<ValidationFailure> Validate(Order context)
        {
            var failures = new List<ValidationFailure>();

            if (context.Total < 200 && !context.DiscountPercent.Equals(0f))
            {
                failures.Add( new ValidationFailure(nameof(context.DiscountPercent), "Discounts cannot be applied to orders under $200."));
            }
            if ((context.Total > 200 & context.Total <= 1000) & context.DiscountPercent > .05)
            {
                failures.Add(new ValidationFailure(nameof(context.DiscountPercent), $"Discount for order ${context.Total} cannot be more than 5%"));
            }
            if (context.Total > 1000 & context.DiscountPercent > .2)
            {
                failures.Add(new ValidationFailure(nameof(context.DiscountPercent), $"Discount for order ${context.Total} cannot be more than 20%"));
            }
            return failures;
        }
    }
}
