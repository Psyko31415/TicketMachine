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
                buttons.Add((i % 2 == 0 ? "Add " : "Sub ") + ticketData[(i - 2) / 2].Title, new Button(alterTicket));
            }

            ui = new UserInterface(buttons);
            transactions = new Dictionary<Person, TicketMachineTransaction>(5);
            history = new List<TicketMachineHistory>(5);
        }

        private Interaction.Status cancelOrder(Person p, Button b)
        {
            try
            {
                history.Add(new TicketMachineHistory(transactions[p], p, TicketMachineHistory.Action.Canceled));
                transactions.Remove(p);
                return Interaction.Status.Ok;
            }
            catch (KeyNotFoundException e)
            {
                return Interaction.Status.KeyNotFoundError;
            }
        }

        private Interaction.Status buyTickets(Person p, Button b)
        {
            try
            {
                return Interaction.Status.Ok;
            }
            catch (KeyNotFoundException e)
            {
                return Interaction.Status.KeyNotFoundError;
            }
        }

        public Interaction.Status alterTicket(Person p, Button b)
        {
            return Interaction.Status.Ok;
        }

        public Interaction.Status[] Interact(Person p, Interaction action)
        {
            return action.Execute(ui, p);
        }
    }
}
