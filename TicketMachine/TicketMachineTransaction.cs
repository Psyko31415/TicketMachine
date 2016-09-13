using System.Collections.Generic;
using System.Text;

namespace TicketMachine
{
    public class TicketMachineTransaction
    {
        private Dictionary<TicketData, int> bufferedTickets;

        public TicketMachineTransaction(TicketData[] ticketData)
        {
            bufferedTickets = new Dictionary<TicketData, int>(ticketData.Length);
            for (int i = 0; i < ticketData.Length; i++)
            {
                bufferedTickets.Add(ticketData[i], 0);
            }
        }

        public string ToString(string indentation)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<TicketData, int> pair in bufferedTickets)
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