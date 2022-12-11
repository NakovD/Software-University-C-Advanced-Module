namespace ChristmasPastryShop.Core
{
    using ChristmasPastryShop.Core.Contracts;
    using ChristmasPastryShop.Models.Booths;
    using ChristmasPastryShop.Models.Cocktails;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories;
    using ChristmasPastryShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using System.Threading;

    public class Controller : IController
    {
        private BoothRepository booths;

        public Controller()
        {
            booths = new BoothRepository();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        public string AddBooth(int capacity)
        {
            var boothId = booths.Models.Count + 1;
            var booth = new Booth(boothId, capacity);

            booths.AddModel(booth);

            return String.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == cocktailTypeName);
            if (type == null) return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);

            var isSizeValid = ValidateCocktailSize(size);
            if (!isSizeValid) return string.Format(OutputMessages.InvalidCocktailSize, size);

            var neededBooth = booths.Models.SingleOrDefault(b => b.BoothId == boothId);

            var doesCocktailExist = neededBooth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size);
            if (doesCocktailExist) return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);

            ICocktail delicacy;

            if (cocktailTypeName == "Hibernation") delicacy = new Hibernation(cocktailName, size);
            else delicacy = new MulledWine(cocktailName, size);

            neededBooth.CocktailMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        private bool ValidateCocktailSize(string size)
        {
            if (size != "Small" && size != "Middle" && size != "Large") return false;
            return true;
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == delicacyTypeName);
            if (type == null) return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);

            var neededBooth = booths.Models.SingleOrDefault(b => b.BoothId == boothId);

            var doesDelicacyExist = neededBooth.DelicacyMenu.Models.Any(d => d.Name == delicacyName);
            if (doesDelicacyExist) return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);

            IDelicacy delicacy;

            if (delicacyTypeName == "Gingerbread") delicacy = new Gingerbread(delicacyName);
            else delicacy = new Stolen(delicacyName);

            neededBooth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            var neededBooth = booths.Models.SingleOrDefault(b => b.BoothId == boothId);

            var report = neededBooth.ToString();

            return report;
        }

        public string LeaveBooth(int boothId)
        {
            var neededBooth = booths.Models.SingleOrDefault(b => b.BoothId == boothId);
            var bill = $"{neededBooth.CurrentBill:F2}";

            neededBooth.Charge();
            neededBooth.ChangeStatus();

            var sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.GetBill, bill));
            sb.AppendLine(string.Format(OutputMessages.BoothIsAvailable, boothId));

            return sb.ToString().Trim();
        }

        public string ReserveBooth(int countOfPeople)
        {
            var orderedBooths = booths.Models
                .Where(b => !b.IsReserved && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId);

            var firstBooth = orderedBooths.FirstOrDefault();
            if (firstBooth == null) return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);

            firstBooth.ChangeStatus();

            return String.Format(OutputMessages.BoothReservedSuccessfully, firstBooth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            var neededBooth = booths.Models.SingleOrDefault(b => b.BoothId == boothId && b.IsReserved);
            var orderData = order.Split("/");
            var itemTypeName = orderData[0];
            var itemName = orderData[1];
            var itemCount = int.Parse(orderData[2]);
            var cocktailSize = orderData.Length == 4 ? orderData[3] : string.Empty;

            var isCocktail = orderData.Length == 4 && itemTypeName == "MulledWine" || itemTypeName == "Hibernation";

            var doesItemTypeExist = Assembly.GetExecutingAssembly().GetTypes().Any(t => t.Name == itemTypeName);
            if (!doesItemTypeExist) return String.Format(OutputMessages.NotRecognizedType, itemTypeName);

            var doesItemExistInBooth = isCocktail ? neededBooth.CocktailMenu.Models.Any(c => c.Name == itemName)
                : neededBooth.DelicacyMenu.Models.Any(d => d.Name == itemName);

            if (!doesItemExistInBooth) return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);

            if (isCocktail)
            {
                var neededCocktail = neededBooth.CocktailMenu.Models.SingleOrDefault(c => c.GetType().Name == itemTypeName && c.Name == itemName && c.Size == cocktailSize);

                if (neededCocktail == null) return String.Format(OutputMessages.CocktailStillNotAdded, cocktailSize, itemName);

                var bill = neededCocktail.Price * itemCount;

                neededBooth.UpdateCurrentBill(bill);

                return String.Format(OutputMessages.SuccessfullyOrdered, boothId, itemCount, itemName);
            }

            var neededDelicacy = neededBooth.DelicacyMenu.Models.SingleOrDefault(d => d.GetType().Name == itemTypeName && d.Name == itemName);

            var delicacyBill = neededDelicacy.Price * itemCount;

            neededBooth.UpdateCurrentBill(delicacyBill);

            return String.Format(OutputMessages.SuccessfullyOrdered, boothId, itemCount, itemName);
        }
    }
}
