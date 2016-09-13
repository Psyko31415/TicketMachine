using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            TicketMachine tm = new TicketMachine(
                new TicketData(2, 10.0, "Junior Ticket"),
                new TicketData(22, 15.0, "Adult Ticket"),
                new TicketData(101, 20.0, "Senior Ticket")
            );

            Person[] people =
            {
                new Person("Anton", 18, new BankAccount(304.3)),
                new Person("Pommes", 23, new BankAccount(954)),
                new Person("Daniel", 83, new BankAccount(3.7)),
                new Person("Bierman", 3, new BankAccount(9001.420))
            };

            Interaction[] interactions =
            {
                new Interaction("press 'Add Junior Ticket' x2; press 'Add Adult Ticket' x4; press 'Buy'; print 'string with \\';\\'';"),
                new Interaction(""),
                new Interaction(""),
                new Interaction(""),
            };

            for (int i = 0; i < Math.Min(people.Length, interactions.Length); i++)
            {
                people[i].Interact(tm, interactions[i]);
            }
        }
    }
}
