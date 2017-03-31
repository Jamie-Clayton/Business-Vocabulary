namespace Examples.Vocabulary
{
    /// <summary>
    /// Business Rules can belong to groups to help filter validation to a subset of business rules.
    /// We also don't want magic strings in our application.
    /// </summary>
    public static class BusinessRuleGroup
    {
        public const string DiscountPolicy = "DiscountPolicy";
        public const string OrderPolicy = "OrderPolicy";
    }
}
