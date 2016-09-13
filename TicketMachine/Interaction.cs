namespace TicketMachine
{
    public class Interaction
    {
        private const string[] functions = ['press'];

        private string code;

        public Interaction(string code)
        {
            this.code = code;

            for (int i = 0; i < code.Length; i++)
            {
                char c = code[i];
                foreach (string function in functions)
                {
                    if ()
                }
            }
        }


    }
}