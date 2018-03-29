using System;

namespace BankSystem
{
    public abstract class AbstractAccount
    {
        private string accountNumber;
        private string name;
        private decimal balance;
        private int bonusPoints;

        public string AccountNumber
        {
            get => accountNumber;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    accountNumber = value;
                }
                else
                {
                    throw new ArgumentException(nameof(accountNumber));
                }
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException(nameof(name));
                }
            }
        }

        public decimal Balance
        {
            get => balance;
            private set
            {
                if (IsValidBalance(value))
                {
                    balance = value;
                }
                else
                {
                    throw new ArgumentException(nameof(balance));
                }
            }
        }

        public int BenefitPoints
        {
            get => bonusPoints;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }
            Balance += amount;
            bonusPoints += CalculateBanefitPoints(amount);
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }
            Balance -= amount;
            bonusPoints -= CalculateBanefitPoints(amount);
        }

        protected abstract bool IsValidBalance(decimal value);

        protected abstract int CalculateBanefitPoints(decimal amount);
    }
}
