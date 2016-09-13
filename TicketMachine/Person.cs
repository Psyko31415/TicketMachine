namespace TicketMachine
{
    public class Person
    {
        private BankAccount bankAccount;
        private string name;
        private int age;

        public Person(string name, int age, BankAccount bankAccount)
        {
            this.name = name;
            this.age = age;
            this.bankAccount = bankAccount;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} Age: {1} Money: {2}", name, age, bankAccount);
        }

        public bool Interact(Interactable obj)
        {
            return obj.Interact(this);
        }

        public BankAccount BankAccount
        {
            get
            {
                return bankAccount;
            }
        }
    }
}