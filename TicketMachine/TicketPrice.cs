namespace TicketMachine
{
    public class TicketData
    {
        private int minAge;
        private AMU cost;
        private string title;

        public TicketData(int minAge, AMU cost, string title)
        {
            this.minAge = minAge;
            this.cost = cost;
            this.title = title;
        }

        public TicketData(int minAge, int balance, string title) : this(minAge, new AMU(balance), title) {}
        public TicketData(int minAge, double balance, string title) : this(minAge, new AMU(balance), title) {}

        public string Title
        {
            get
            {
                return title;
            }
        }

        public AMU Cost
        {
            get
            {
                return cost;
            }
        }

        public int MinAge
        {
            get
            {
                return minAge;
            }
        }
    }
}