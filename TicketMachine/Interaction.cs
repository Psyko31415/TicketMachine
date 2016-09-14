using System;
using System.Collections.Generic;
using System.Text;

namespace TicketMachine
{
    public class SyntaxError : Exception
    {
        public SyntaxError(string message) : base(message){ }
    }

    public class Interaction
    {
        public enum Status
        {
            Illegal,
            Ok,
            KeyNotFoundError
        }

        private List<Section> sections;

        public Interaction(string code)
        {
            sections = new List<Section>();

            bool inString = false;
            int sectionStart = 0;

            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == ';')
                {
                    if (!inString)
                    {
                        sections.Add(new Section(code.Substring(sectionStart, i - sectionStart).Trim()));
                        sectionStart = i + 1;
                    }
                }
                else if (code[i] == '\'' && (i < 1 || code[i - 1] != '\\'))
                {
                    inString = !inString;
                }
            }

            if (inString)
            {
                throw new SyntaxError("String not closed");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Interaction:\n");
            foreach (Section s in sections)
            {
                sb.AppendFormat("  {0};\n", s);
            }
            return sb.ToString();
        }

        public Interaction.Status[] Execute(UserInterface ui, Person p)
        {
            Interaction.Status[] ret = new Interaction.Status[sections.Count];
            for (int i = 0; i < sections.Count; i++)
            {
                ret[i] = sections[i].Execute(ui, p);
            }
            return ret;
        }
    }
}