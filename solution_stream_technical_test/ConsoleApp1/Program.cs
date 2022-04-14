using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var transaction1 = new Transaction(DateTime.Parse("1/1/2000"), 1);

            var transaction2 = new Transaction(DateTime.Parse("1/2/2001"), 1);

            var transaction3 = new Transaction(DateTime.Parse("1/1/2000"), -2);

            var transaction4 = new Transaction(DateTime.Parse("1/2/2000"), -3);

            var list = new List<ITransaction>
            {
                transaction1,
                transaction2,
                transaction3,
                transaction4,
            };

            Dictionary<int, decimal> sumByYear = list.BreakdownByYear(a => a.Sum(b => b.Amount));
            var sumByYearByMonth = list.BreakdownByYearByMonth(a => a.Sum(b => b.Amount));
            var averageByYear = list.BreakdownByYear(a => a.Average(b => b.Amount));
            var averageByYearByMonth = list.BreakdownByYearByMonth(a => a.Average(b => b.Amount));
            Dictionary<int, int> countByYear = list.BreakdownByYear(a => a.Count());
        }
    }

    public enum TransactionType
    {
        Income,
        Expense
    }

    public interface ITransaction
    {
        DateTime Date { get; }

        decimal Amount { get; }

        TransactionType TransactionType { get; }
    }

    public class Transaction : ITransaction, IValidatableObject
    {
        public Transaction(DateTime date, decimal amount)
        {
            Date = date;
            Amount = amount;
        }

        public DateTime Date { get; }

        public decimal Amount { get; }

        public TransactionType TransactionType => Amount > 0 ? TransactionType.Income : TransactionType.Expense;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Amount == 0)
            {
                yield return new ValidationResult("The amount can't be zero.");
            }
        }

    }

    public static class TransactionExtensions
    {
        public static Dictionary<int, T> BreakdownByYear<T>(this IEnumerable<ITransaction> transactions, Func<IGrouping<int, ITransaction>, T> func)
        {
            return transactions.GroupBy(a => a.Date.Year).ToDictionary(a => a.Key, func);
        }

        public static Dictionary<int, Dictionary<int, T>> BreakdownByYearByMonth<T>(this IEnumerable<ITransaction> transactions, Func<IGrouping<int, ITransaction>, T> func)
        {
            return transactions.GroupBy(a => a.Date.Year).ToDictionary(a => a.Key, a => a.GroupBy(b => b.Date.Month).ToDictionary(c => c.Key, func));
        }
    }
}
