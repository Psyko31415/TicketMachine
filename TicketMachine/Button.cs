using System;

namespace TicketMachine
{
    public delegate bool Action(Person p);
    public class Button : Interactable
    {
        private string title;
        private Action action;

        public Button(string title, Action action)
        {
            this.title = title;
            this.action = action;
        }

        public bool Interact(Person p)
        {
            return action(p);
        }
    }
}