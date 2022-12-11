namespace Composite.Models
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    internal class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;

        public CompositeGift(string name, decimal price) : base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift) => gifts.Add(gift);

        public override decimal CalculateTotalPrice() => gifts.Sum(gift => gift.CalculateTotalPrice());

        public void Remove(GiftBase gift) => gifts.Remove(gift);
    }
}
