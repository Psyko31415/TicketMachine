using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMachine
{
    public interface Interactable
    {
        Interaction.Status[] Interact(Person p, Interaction action);
    }
}
