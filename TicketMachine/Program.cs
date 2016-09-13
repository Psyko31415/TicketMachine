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
                new TicketPrice(2, 10.0),
                new TicketPrice(22, 15.0),
                new TicketPrice(101, 20.0)
            );

            Person[] people =
            {
                new Person("Anton", 18, new BankAccount(304.3)),
                new Person("Pommes", 23, new BankAccount(954)),
                new Person("Daniel", 83, new BankAccount(3.7)),
                new Person("Bierman", 3, new BankAccount(9001.420))
            };

            foreach (Person person in people)
            {
                person.Interact(tm);
            }
        }
    }
}
