using System;

namespace Ultramarine.QueryLanguage.Cli
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(28591);
            Console.WriteLine(Logo.Art);
            Console.WriteLine("Ultramarine QueryLanguage CLI");
            Console.ResetColor();
            
            while (true)
            {
                Console.Write('>');
                var input = Console.ReadLine();
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                try
                {
                    var compiler = new ConditionCompiler(input);
                    Console.WriteLine(compiler.Execute());
                }
                catch
                {
                    //TODO: proper parsing error
                    Console.WriteLine("Can't understand that expression. Yet!");
                }
            }

        }
    }

}
