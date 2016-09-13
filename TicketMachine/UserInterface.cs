using System.Collections.Generic;
using System.Text;

namespace TicketMachine
{
    public class UserInterface
    {
        private Dictionary<string, Button> buttons;
        public UserInterface(Dictionary<string, Button> buttons)
        {
            this.buttons = buttons;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("UI:\n");
            foreach (KeyValuePair<string, Button> button in buttons)
            {
                sb.AppendFormat("  {0}\n", button.Key);
            }
            return sb.ToString();
        }

        public Button this[string key]
        {
            get
            {
                return buttons[key];
            }
            set
            {
                buttons.Add(key, value);
            }
        }


    }
}