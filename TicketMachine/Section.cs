using System;
using System.Collections.Generic;

namespace TicketMachine
{
    internal class Section
    {
        private string code;
        private static Dictionary<string, ScriptFunctionDef> functions = new Dictionary<string, ScriptFunctionDef>()
        {
            { "press", new ScriptFunctionDef(ScriptFunctionDef.Type.String) },
            { "print", new ScriptFunctionDef(ScriptFunctionDef.Type.String) }
        };

        public Section(string code)
        {
            this.code = code;
            Console.WriteLine(code);
        }

        public Interaction.Status Execute(UserInterface ui, Person p)
        {
            return Interaction.Status.Ok;
        }

        public Interaction.Status Press(UserInterface ui, Person p, string target)
        {
            try
            {
                return ui[target].Press(p);
            }
            catch (KeyNotFoundException e)
            {
                return Interaction.Status.KeyNotFoundError;
            }
            catch
            {
                return Interaction.Status.Illegal;
            }
        }

        public Interaction.Status print(string s)
        {
            Console.WriteLine(s);
            return Interaction.Status.Ok;
        }

        public override string ToString()
        {
            return code;
        }
    }
}