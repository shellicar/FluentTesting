using System.Linq;
using Core;

namespace Architecture
{
    public class ResultTester : IResultTester
    {
        public string Transform(string input)
        {
            return new string(input.Reverse().ToArray());
        }
    }
}
