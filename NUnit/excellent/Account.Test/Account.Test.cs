using System;
using NUnit.Framework;

namespace Account.Test
{
    [TestFixture]
    public class AccountTest
    {
        [Test]
        public void SeedIncrement_Test()
        {
            //TODO: accountNumberSeed is incremented after each Account initialization
            Account account1 = new Account();
            Account account2 = new Account();

            var result = decimal.Parse(account2.Number) - decimal.Parse(account1.Number);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void EmptyConstructor_Test()
        {
            //TODO: account initialized with empty constructor returns Balance equal to 0 and Owner as empty string
            Account account1 = new Account();

            Assert.AreEqual(0, account1.Balance);
            Assert.AreEqual("", account1.Owner);
        }

        [Test]
        public void Deposit_Test()
        {
            //TODO: Deposit method increases Balance with given amount
            Account account1 = new Account();
            Assert.AreEqual(0, account1.Balance);

            var amount = 100;
            account1.Deposit(amount);
            Assert.AreEqual(100, account1.Balance);
        }

        [Test]
        public void NotEmptyConstructor_Test()
        {
            //TODO: account initialized with not empty constructor returns Balance equal to initialBalance and Owner equal to given name
            var balance = 100;
            Account account1 = new Account("xyz", balance);

            Assert.AreEqual("xyz", account1.Owner);
            Assert.AreEqual(100, account1.Balance);
        }

        [Test]
        public void DepositException_Test()
        {
            //TODO: negative amount parameter passed to Deposit method throws ArgumentOutOfRangeException exception
            Account account1 = new Account();
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate
                {
                    account1.Deposit(-100);
                }
            );
        }

        [Test]
        public void Withdraw_Test()
        {
            //TODO: Withdraw method decreases Balance with given amount
            Account account1 = new Account("xyz", 100);
            Assert.AreEqual(100, account1.Balance);

            account1.Withdraw(40);
            Assert.AreEqual(60, account1.Balance);
        }

        [Test]
        public void WithDrawExceptionOutOfRange_Test()
        {
            //TODO: negative amount parameter passed to Withdraw method throws ArgumentOutOfRangeException exception
            Account account1 = new Account();
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate
                {
                    account1.Withdraw(-100);
                }
            );
        }

        [Test]
        public void WithDrawExceptionInvalidOperation_Test()
        {
            //TODO: amount parameter greater than Balance passed to Withdraw method throws InvalidOperationException exception
            Account account1 = new Account("xyz", 10);
            Assert.AreEqual(10, account1.Balance);

            Assert.Throws<InvalidOperationException>(
                delegate
                {
                    account1.Withdraw(100); 

                }
            );
        }
    }
}