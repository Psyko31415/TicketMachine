using System;

namespace TicketMachine
{
    public class Button : Interactable
    {
        public delegate bool Action(Person p, Button b);
        private Action action;

        public Button(Action action)
        {
            this.action = action;
        }

        public bool Interact(Person p)
        {
            return action(p, this);
        }
    }
}