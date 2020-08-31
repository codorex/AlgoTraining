using AlgoTraining._01_Graphs.Core;
using AlgoTraining._01_Graphs.Implementations;

using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTraining._01_Graphs
{
    public class Program
    {
        private static IGraphRelationshipValidator<string> _relationshipValidator;

        private static Graph<string> _graph;

        private const string AreRelatedResultMessage = "Yes";

        private const string NotRelatedResultMessage = "No";

        private const string InputTokenDelimiter = ",";

        private const string InputTerminator = "@";

        public static void Main()
        {
            _graph = new Graph<string>();

            _relationshipValidator = 
                new IterativeGraphRelationshipValidator<string>(_graph);

            List<string> companies = 
                ReadCompanies();

            Dictionary<string, List<string>> companyRelationships = 
                ReadCompanyRelationships();

            foreach (var company in companyRelationships.Keys)
                foreach (var child in companyRelationships[company])
                    _graph.Connect(company, child);

            ReadCompaniesToValidate()
                ?.ForEach(OutputResult);
        }

        private static List<string> ReadCompanies()
        {
            Console.WriteLine(
                "Please, enter the list of companies in the following format: \"A, B, C, D\" ... ");

            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                return new List<string>();
            }

            return input
                .Split(InputTokenDelimiter)
                .Select(x => x.Trim())
                .ToList();
        }

        private static Dictionary<string, List<string>> ReadCompanyRelationships()
        {
            Console.WriteLine(
                "Please, describe the relationships between companies " +
                "in the following format: \"Parent, Subsidiary\".");

            Console.WriteLine(
                $"Enter \"{InputTerminator}\" to complete your list.");

            return ReadListOfPairs()
                .GroupBy(x => x.Key)
                .ToDictionary(
                    gr => gr.Key, 
                    gr => gr.Select(x => x.Value).ToList());
        }

        private static List<KeyValuePair<string, string>> ReadCompaniesToValidate()
        {
            Console.WriteLine(
                "Please, enter the companies you wish to validate the relationship of in pairs " +
                "in the following format: \"A, B\".");

            Console.WriteLine(
                $"Enter \"{InputTerminator}\" to complete your list.");

            return ReadListOfPairs().ToList();
        }

        private static IEnumerable<KeyValuePair<string, string>> ReadListOfPairs()
        {
            string input;

            while ((input = Console.ReadLine()) != InputTerminator)
            {
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }

                string[] tokens = input.Split(InputTokenDelimiter);

                // If the input is not a pair of strings, throw.
                if (tokens.Length != 2)
                {
                    throw new IndexOutOfRangeException();
                }

                string parent = tokens[0].Trim();
                string child = tokens[1].Trim();

                yield return new KeyValuePair<string, string>(parent, child);
            }
        }

        private static void OutputResult(KeyValuePair<string, string> companyPair)
        {
            string result = _relationshipValidator.RelationshipExists(companyPair.Key, companyPair.Value)
                ? AreRelatedResultMessage
                : NotRelatedResultMessage;

            Console.WriteLine($"{companyPair.Key}, {companyPair.Value} - {result}");
        }
    }
}
