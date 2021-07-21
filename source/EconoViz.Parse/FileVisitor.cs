using System.Collections.Generic;
using static EconoViz.Parse.ClausewitzParser;

namespace EconoViz.Parse
{
    public class DocumentVisitor : ClausewitzBaseVisitor<IEnumerable<Assignment>>
    {
        public override IEnumerable<Assignment> VisitDocument(DocumentContext context)
        {
            foreach(var pair in context.assignment())
            {
                yield return new Assignment { Name = pair.field().GetText(), Value = pair.value().GetText() };
            }
        }
    }

    public class Assignment
    {
        public string Name { get; init; }

        public object Value { get; init; }
    }
}
