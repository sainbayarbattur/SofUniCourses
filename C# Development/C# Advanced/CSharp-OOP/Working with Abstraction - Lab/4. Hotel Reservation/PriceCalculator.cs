namespace _4HotelReservation
{
    public static class PriceCalculator
    {
        private const int pricePerDaySpring = 2;

        private const int pricePerDaySummer = 4;

        private const int pricePerDayAutumn = 1;

        private const int pricePerDayWinter = 3;

        private const int discountVip = 20;

        private const int secondTimeDiscountVip  = 10;

        public static decimal GetTotalPrice(decimal pricePerDay, int days, string season, string typeClient)
        {
            int surcharge = 1;
            int discount = 1;
            decimal price = days * pricePerDay;

            if (season == "Spring")
            {
                surcharge = pricePerDaySpring;
            }
            else if (season == "Summer")
            {
                surcharge = pricePerDaySummer;
            }
            else if (season == "Autumn")
            {
                surcharge = pricePerDayAutumn;
            }
            else if (season == "Winter")
            {
                surcharge = pricePerDayWinter;
            }

            if (typeClient == "VIP")
            {
                discount = discountVip;
            }
            else if (typeClient == "SecondVisit")
            {
                discount = secondTimeDiscountVip;
            }

            price *= surcharge;
            if (discount != 1) price -= price * (discount / 100m);

            return price;
        }
    }
}