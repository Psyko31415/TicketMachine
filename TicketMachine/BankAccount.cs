using System;
using System.Runtime.Serialization;

namespace TicketMachine
{
    public class CantOperateOnANegativeAmountException : Exception { }
    public class YouAreTooPoorException : Exception { }

    public class BankAccount
    {
        private AMU balance;
        private string id;

        public BankAccount(double balance) : this(new AMU(balance)) {}

        public BankAccount(AMU balance)
        {
            this.balance = balance;
            id = string.Format("{0}", ((int)this.GetHashCode()).ToString("X8"));
        }

        public AMU Withdraw(AMU amount)
        {
            if (amount < 0)
            {
                throw new CantOperateOnANegativeAmountException();
            }
            if (amount < balance)
            {
                throw new YouAreTooPoorException();
            }
            balance -= amount;
            return balance;
        }

        public AMU Deposit(AMU amount)
        {
            if (amount < 0)
            {
                throw new CantOperateOnANegativeAmountException();
            }
            balance += amount;
            return balance;
        }

        public override string ToString()
        {
            return string.Format("Id: {0} Balance: {1}", id, balance);
        }
    }
}