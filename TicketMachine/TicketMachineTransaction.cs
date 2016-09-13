using System.Collections.Generic;
using System.Text;

namespace TicketMachine
{
    public class TicketMachineTransaction
    {
        private Dictionary<TicketPrice, int> bufferedTickets;

        public TicketMachineTransaction(TicketPrice[] ticketPrices)
        {
            bufferedTickets = new Dictionary<TicketPrice, int>(ticketPrices.Length);
            for (int i = 0; i < ticketPrices.Length; i++)
            {
                bufferedTickets.Add(ticketPrices[i], 0);
            }
        }

        public string ToString(string indentation)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<TicketPrice, int> pair in bufferedTickets)
            {
                sb.AppendFormat("{2}{0} x {1}\n", pair.Value, pair.Key, indentation);
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToString("");
        }

        
    }
}