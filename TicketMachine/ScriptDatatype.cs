using System;

namespace TicketMachine
{
    public class ScriptDatatype
    {
        private ScriptFunction.Type type;
        private int ival;
        private string sval;
        
        public ScriptDatatype(ScriptFunction.Type type, string data)
        {
            this.type = type;
            switch (type)
            {
                case ScriptFunction.Type.String:
                    if (data.Length > 2)
                    {
                        if (data[0] == '\'' && data[data.Length - 1] == '\'')
                        {
                            sval = data.Substring(1, data.Length - 2);
                        }
                        else
                        {
                            throw new SyntaxError("Invalid string format");
                        }
                    }
                    else
                    {
                        throw new SyntaxError("Invalid string format");
                    }
                    break;

                case ScriptFunction.Type.Int:
                    break;
            }
        }

        public ScriptFunction.Type Type
        {
            get
            {
                return type;
            }
        }

        public string String
        {
            get
            {
                return sval;
            }
        } 
        
        public int Int
        {
            get
            {
                return ival;
            }
        }       
    }
}