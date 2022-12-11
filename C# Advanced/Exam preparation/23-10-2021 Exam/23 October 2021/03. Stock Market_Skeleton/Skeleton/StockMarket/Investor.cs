using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public List<Stock> Portfolio { get; set; }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }

        public int Count { get => this.Portfolio.Count; }

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization <= 10000) return;
            if (MoneyToInvest < stock.PricePerShare) return;

            MoneyToInvest -= stock.PricePerShare;
            Portfolio.Add(stock);
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            var doesCompanyExist = Portfolio.Any(stock => stock.CompanyName == companyName);
            if (!doesCompanyExist) return $"{companyName} does not exist.";
            var neededStock = Portfolio.Find(stock => stock.CompanyName == companyName);
            if (sellPrice < neededStock.PricePerShare) return $"Cannot sell {companyName}.";

            Portfolio.Remove(neededStock);
            MoneyToInvest += sellPrice;

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            var neededStock = this.Portfolio.SingleOrDefault(stock => stock.CompanyName == companyName);

            return neededStock;
        }

        public Stock FindBiggestCompany()
        {
            if (this.Portfolio.Count == 0) return null;
            var sortedStocks = this.Portfolio.OrderByDescending(stock => stock.MarketCapitalization);
            var neededStock = this.Portfolio.Take(1).ToList()[0];

            return neededStock;
        }

        public string InvestorInformation()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            sb.AppendLine(string.Join(Environment.NewLine, this.Portfolio));

            return sb.ToString().Trim();
        }
    }
}
