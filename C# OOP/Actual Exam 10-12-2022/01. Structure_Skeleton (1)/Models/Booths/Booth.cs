namespace ChristmasPastryShop.Models.Booths
{
    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories;
    using ChristmasPastryShop.Repositories.Contracts;
    using ChristmasPastryShop.Utilities.Messages;
    using System;
    using System.Linq;
    using System.Text;

    public class Booth : IBooth
    {
        private int boothId;

        public int BoothId { get => boothId; private set => boothId = value; }

        private int capacity;

        public int Capacity
        {
            get => capacity;

            private set
            {
                if (value <= 0) throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                capacity = value;
            }
        }

        private IRepository<IDelicacy> delicacyMenu;

        public IRepository<IDelicacy> DelicacyMenu { get => delicacyMenu; }

        private IRepository<ICocktail> cocktailMenu;

        public IRepository<ICocktail> CocktailMenu { get => cocktailMenu; }

        private double currentBill;

        public double CurrentBill { get => currentBill; private set => currentBill = value; }

        private double turnover;

        public double Turnover { get => turnover; private set => turnover = value; }

        private bool isReserved;

        public bool IsReserved { get => isReserved; private set => isReserved = value; }

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            delicacyMenu = new DelicacyRepository();
            cocktailMenu = new CocktailRepository();
        }

        public void ChangeStatus() => IsReserved = !IsReserved;

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount) => CurrentBill += amount;

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:F2} lv");
            sb.AppendLine($"-Cocktail menu:");

            var cocktails = string.Join(Environment.NewLine, CocktailMenu.Models.Select(c => $"--{c}"));
            if (cocktails.Length > 0)
            {
                sb.AppendLine(cocktails);
            }

            sb.AppendLine($"-Delicacy menu:");
            var delicacies = string.Join(Environment.NewLine, DelicacyMenu.Models.Select(d => $"--{d}"));
            if (delicacies.Length > 0)
            {
                sb.AppendLine(delicacies);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
