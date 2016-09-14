using System;
using System.Collections.Generic;

namespace TicketMachine
{
    public class Section
    {
        public delegate Interaction.Status ScriptAction(UserInterface ui, Person p, ScriptDatatype[] parameters);

        private static Dictionary<string, ScriptFunction> functions = new Dictionary<string, ScriptFunction>()
        {
            { "press", new ScriptFunction(Press, "press", ScriptFunction.Type.String) },
            { "print", new ScriptFunction(Print, "print", ScriptFunction.Type.String) }
        };

        private string code;
        private int iterations;
        private ScriptDatatype[] parameters;
        private ScriptFunction function;

        public Section(string code)
        {
            this.code = code;
            List<string> parts = new List<string>();
            int lastPartStart = 0;

            bool inString = false;
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == '\'' && (i < 1 || code[i - 1] != '\\'))
                {
                    inString = !inString;
                }
                else if(code[i] == ' ' && !inString)
                {
                    parts.Add(code.Substring(lastPartStart, i - lastPartStart));
                    lastPartStart = i + 1;
                }
            }

            if (parts.Count > 0)
            {
                bool functionFound = false;
                foreach (KeyValuePair<string, ScriptFunction> func in functions)
                {
                    if (func.Key == parts[0])
                    {
                        functionFound = true;
                        function = func.Value;
                        break;
                    }
                }
                if (functionFound)
                {
                    int hasIteration = 0;
                    if (parts[parts.Count - 1][0]  == 'x')
                    {
                        try
                        {
                            iterations = Convert.ToInt32(parts[parts.Count - 1].Substring(1));
                            hasIteration = 1;
                        }
                        catch (FormatException e)
                        {
                            throw new SyntaxError(string.Format("Invalid format for iterations ({0} expected xN where N is int )", parts[parts.Count - 1]));
                        }
                        catch (OverflowException e)
                        {
                            throw new SyntaxError("Iteration counter too big max 2**31 - 1");
                        }
                    }
                    else
                    {
                        iterations = 1;
                    }
                    int numberOfArgument = parts.Count - hasIteration - 1;
                    if (function.Types.Length == numberOfArgument)
                    {
                        parameters = new ScriptDatatype[numberOfArgument];
                        for (int i = 1; i < parts.Count - hasIteration; i++)
                        {
                            parameters[i - 1] = new ScriptDatatype(function.Types[i - 1], parts[i]);
                        }
                    }
                    else
                    {
                        throw new SyntaxError(string.Format("Number of argument does not match got {0} expected {1}, {2}", numberOfArgument, function.Types.Length, code));
                    }
                }
                else
                {
                    throw new SyntaxError(string.Format("Undefined symbol {0}", parts[0]));
                }
            }
            else
            {
                throw new SyntaxError(string.Format("No function found in code {0}", code));
            }
        }

        public Interaction.Status Execute(UserInterface ui, Person p)
        {
            return function.Call(ui, p, parameters);
        }

        public static Interaction.Status Press(UserInterface ui, Person p, ScriptDatatype[] parameters)
        {
            string key = parameters[0].String;
            try
            {
                return ui[key].Press(p);
            }
            catch (KeyNotFoundException e)
            {
                return Interaction.Status.KeyNotFoundError;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Interaction.Status.Illegal;
            }
        }

        public static Interaction.Status Print(UserInterface ui, Person p, ScriptDatatype[] parameters)
        {
            Console.WriteLine(parameters[0].String);
            return Interaction.Status.Ok;
        }

        public override string ToString()
        {
            return code;
        }
    }
}