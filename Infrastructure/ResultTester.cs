using System.Linq;
using Core;

namespace Infrastructure
{
    public class ResultTester : IResultTester
    {
        public string Transform(string input)
        {
            return new string(input.Reverse().ToArray());
        }
    }
}
