namespace TicketMachine
{
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
                throw new CantWithdrawANegativeAmountException();
            }
        }

        public override string ToString()
        {
            return string.Format("Id: {0} Balance: {1}", id, balance);
        }
    }
}