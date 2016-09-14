using System;

namespace TicketMachine
{
    public class ScriptFunction
    {
        public enum Type
        {
            String,
            Int
        };

        private Type[] types;
        private Section.ScriptAction action;
        private string name;

        public ScriptFunction(Section.ScriptAction action, string name, params Type[] types)
        {
            this.types = types;
            this.action = action;
            this.name = name;
        }

        public Interaction.Status Call(UserInterface ui, Person p, ScriptDatatype[] parameters)
        {
            return action(ui, p, parameters);
        }

        public bool ValidateParameters(ScriptDatatype[] parameters)
        {
            if (parameters.Length == types.Length)
            {
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != parameters[i].Type)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                throw new SyntaxError(string.Format("Too few or too many arguments supplied to function '{0}' ({1} expected {2})", name, parameters.Length, types.Length));
            }
        }

        public Type[] Types
        {
            get
            {
                return types;
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
}