using AccountWithdraw.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountWithdraw.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > WithdrawLimit)
                throw new DomainException(String.Format("You can't request this quantity! Quantity permitted: {0}",WithdrawLimit));

            if(amount > Balance)
                throw new DomainException("You don't have enough money to request that amount");

            Balance -= amount;
        }
    }
}