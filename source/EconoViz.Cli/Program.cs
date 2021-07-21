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
            using var file = File.OpenRead(@"C:\projects\EconoViz\source\EconoViz.Tests\gamestate.txt");
            using var fileStream = new StreamReader(file, Encoding.UTF8);
            var antlrStream = new AntlrInputStream(fileStream);

            var lexer = new ClausewitzLexer(antlrStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new ClausewitzParser(tokenStream);

            var visitor = new DocumentVisitor();
            var b = visitor.Visit(parser.document());
        }
    }
}
