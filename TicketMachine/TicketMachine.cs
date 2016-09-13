using System;
using System.Collections.Generic;

namespace TicketMachine
{
    public class TicketMachine : Machine, Interactable
    {
        private TicketPrice[] ticketPrices;
        private Dictionary<Person, TicketMachineTransaction> transactions;
        private List<TicketMachineHistory> history;

        public TicketMachine(params TicketPrice[] ticketPrices)
        {
            this.ticketPrices = ticketPrices;
            ui = new UserInterface(
                new Button("Buy", buyTickets),
                new Button("Cancel", cancelOrder)
            );
            transactions = new Dictionary<Person, TicketMachineTransaction>(5);
            history = new List<TicketMachineHistory>(5);
        }

        private bool cancelOrder(Person p)
        {
            try
            {
                history.Add(new TicketMachineHistory(transactions[p], p, TicketMachineHistory.Action.Canceled));
                transactions.Remove(p);
                return true;
            }
            catch (KeyNotFoundException e)
            {
                return false;
            }
        }

        private bool buyTickets(Person p)
        {
            try
            {
                p.
                return true;
            }
            catch (KeyNotFoundException e)
            {
                return false;
            }
        }

        private void changeTicketsHelper(Person p)
        {
            if (!transactions.ContainsKey(p))
            {
                transactions.Add(p, new TicketMachineTransaction(ticketPrices));
            }
        }

        public bool Interact(Person p)
        {
            return true;
        }
    }
}
