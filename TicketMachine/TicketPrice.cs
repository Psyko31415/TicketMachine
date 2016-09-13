namespace TicketMachine
{
    public class TicketPrice
    {
        private int minAge;
        private AMU balance;

        public TicketPrice(int minAge, AMU balance)
        {
            this.minAge = minAge;
            this.balance = balance;
        }

        public TicketPrice(int minAge, int balance) : this(minAge, new AMU(balance)) { }
        public TicketPrice(int minAge, double balance) : this(minAge, new AMU(balance)) {}
    }
}