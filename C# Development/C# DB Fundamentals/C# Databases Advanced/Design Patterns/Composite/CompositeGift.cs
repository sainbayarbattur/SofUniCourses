namespace Composite
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class CompositeGift : GiftBase, IGiftOperations
    {
        private ICollection<GiftBase> gifts;

        public CompositeGift(string name, int price)
            : base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            this.gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            return gifts.Sum(g => g.CalculateTotalPrice());
        }
    }
}