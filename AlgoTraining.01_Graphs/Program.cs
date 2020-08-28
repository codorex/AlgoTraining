using AlgoTraining._01_Graphs.Core;
using AlgoTraining._01_Graphs.Implementations;

using System;
using System.Collections.Generic;

namespace AlgoTraining._01_Graphs
{
    public class Program
    {
        private static IGraphRelationshipValidator<string> _relationshipValidator;

        private static Graph<string> _graph;

        private const string AreRelatedResultMessage = "Yes";

        private const string NotRelatedResultMessage = "No";

        public static void Main()
        {
            _graph = new Graph<string>();

            _relationshipValidator = new IterativeGraphRelationshipValidator<string>(_graph);

            _graph.Connect("A", "B");
            _graph.Connect("B", "F");
            _graph.Connect("F", "A");
            _graph.Connect("B", "C");
            _graph.Connect("C", "D");

            ReadCompaniesToValidate()
                ?.ForEach(OutputResult);
        }

        private static List<string> ReadCompanies()
        {
            throw new NotImplementedException();
        }

        private static Dictionary<string, string> ReadCompanyRelationships()
        {
            throw new NotImplementedException();
        }

        private static List<KeyValuePair<string, string>> ReadCompaniesToValidate() =>
            new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("A", "B"),
                new KeyValuePair<string, string>("A", "C"),
                new KeyValuePair<string, string>("A", "D"),
                new KeyValuePair<string, string>("D", "B")
            };

        private static void OutputResult(KeyValuePair<string, string> companyPair)
        {
            string result = _relationshipValidator.RelationshipExists(companyPair.Key, companyPair.Value)
                ? AreRelatedResultMessage
                : NotRelatedResultMessage;

            Console.WriteLine($"{companyPair.Key}, {companyPair.Value} - {result}");
        }
    }
}
