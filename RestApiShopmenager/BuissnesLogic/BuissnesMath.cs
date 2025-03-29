namespace RestApiShopmenager.BuissnesLogic
{
    public static class BuissnesMath
    {
        public static decimal CalculateTotal(int quantity, decimal price, decimal discount)
        {
            return quantity * price*(1-discount/100);
        }
    }
}
