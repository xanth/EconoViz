using Antlr4.Runtime;
using EconoViz.Parse;
using System.IO;
using System.Text;

namespace EconoViz.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            using var file = File.OpenRead(@"C:\projects\ck3save\assets\saves\Jarl_Ivar_of_the_Isles_867_01_01.ck3");
            using var fileStream = new StreamReader(file, Encoding.UTF8);
            var antlrStream = new AntlrInputStream(fileStream);

            var lexer = new ClausewitzLexer(antlrStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new ClausewitzParser(tokenStream);

            var a = parser.content();
        }
    }
}
