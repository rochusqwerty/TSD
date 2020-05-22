using System;
using System.Collections.Generic;

namespace Account
{
    public class Account
    {
        private static int accountNumberSeed = 1234567890;
        private List<Transaction> allTransactions = new List<Transaction>();
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                return GetBalance();
            }
        }

        //hint: Balance should be counted as sum of all transactions
        private decimal GetBalance()
        {
            //TODO implement
            decimal balance = 0;
            foreach (var t in allTransactions)
                balance += t.Amount;

            return balance;
        }

        public Account(string name, decimal initialBalance)
        {
            //TODO implement
            this.Owner = name;
            this.Number = accountNumberSeed++.ToString();

            allTransactions.Add(new Transaction(initialBalance));
        }

        public Account()
        {
            //TODO implement
            this.Owner = "";
            this.Number = accountNumberSeed++.ToString();
        }

        public void Deposit(decimal amount)
        {
            //TODO implement
            if (amount < 0) 
                throw new ArgumentOutOfRangeException();

            allTransactions.Add(new Transaction(amount));
        }

        public void Withdraw(decimal amount)
        {
            //TODO implement
            if (amount < 0)
                throw new ArgumentOutOfRangeException();
            
            if (Balance - amount < 0)
                throw new InvalidOperationException();

            allTransactions.Add(new Transaction(-amount));
        }
    }
}
