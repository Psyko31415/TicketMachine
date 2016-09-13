using System;

namespace TicketMachine
{
    public class Button
    {
        public delegate Interaction.Status Action(Person p, Button b);
        private Action pressAction;

        public Button(Action action)
        {
            this.pressAction = action;
        }

        public Interaction.Status Press(Person p)
        {
            return pressAction(p, this);
        }
    }
}