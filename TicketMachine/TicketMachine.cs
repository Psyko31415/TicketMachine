using System;
using System.Collections.Generic;

namespace TicketMachine
{
    public class TicketMachine : Machine, Interactable
    {
        private TicketData[] ticketData;
        private Dictionary<Person, TicketMachineTransaction> transactions;
        private List<TicketMachineHistory> history;

        public TicketMachine(params TicketData[] ticketData)
        {
            this.ticketData = ticketData;
            Dictionary<string, Button> buttons = new Dictionary<string, Button>(ticketData.Length * 2 + 2);
            buttons.Add("Buy", new Button(buyTickets));
            buttons.Add("Cancel", new Button(cancelOrder));
            
            for (int i = 2; i < ticketData.Length * 2 + 2; i++)
            {
                buttons.Add(i % 2 == 0 ? "Add " : "Sub " + ticketData[(i - 2) / 2].Title, new Button(alterTicket));
            }

            ui = new UserInterface(buttons);
            transactions = new Dictionary<Person, TicketMachineTransaction>(5);
            history = new List<TicketMachineHistory>(5);
        }

        private bool cancelOrder(Person p, Button b)
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

        private bool buyTickets(Person p, Button b)
        {
            try
            {
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
                transactions.Add(p, new TicketMachineTransaction(ticketData));
            }
        }

        public bool alterTicket(Person p, Button b)
        {
            return true;
        }

        public bool Interact(Person p)
        {
            return true;
        }
    }
}
