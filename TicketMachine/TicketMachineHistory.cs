using System.ComponentModel;

namespace TicketMachine
{
    public class TicketMachineHistory
    {
        public enum Action
        {
            Canceled,
            Accepted,
            Denied
        };

        private TicketMachineTransaction history;
        private Person person;
        private Action action;

        public TicketMachineHistory(TicketMachineTransaction history, Person person, Action action)
        {
            this.history = history;
            this.person = person;
            this.action = action;
        }

        public override string ToString()
        {
            return string.Format("Person: {0}, {2} \n{1}", person, history.ToString("  "), action.ToString());
        }
    }
}