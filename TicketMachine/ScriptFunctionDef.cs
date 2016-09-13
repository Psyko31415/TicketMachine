namespace TicketMachine
{
    public class ScriptFunctionDef
    {
        private Type[] types;

        public enum Type
        {
            String
        };

        public ScriptFunctionDef(params Type[] types)
        {
            this.types = types;
        }
    }
}