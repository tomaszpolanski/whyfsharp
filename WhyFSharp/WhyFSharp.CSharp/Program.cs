using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WhyFSharp.CSharp;

namespace WhyFSharp.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        #region Working with lists

        private static void FoldText()
        {
            const string text = "This is some text,       this is another line,,yet another,,,";
            var foldedV1 = FoldTextToOneLineV1(text, 5, ":) ");
            var foldedV2 = FoldTextToOneLineV2(text, 5, ":) ");
        }

        private static string FoldTextToOneLineV1(string s, int maxLines, string foldSeperator)
        {
            List<string> lines = new List<string>();
            string[] strings = s.Split('\n', ',', ';');
            foreach (string line in strings)
            {
                string trimmedLine = line.Trim();
                if (trimmedLine.Length > 0)
                {
                    lines.Add(trimmedLine);
                    if (lines.Count >= maxLines)
                    {
                        break;
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lines.Count; i++)
            {
                sb.Append(lines[i]);
                if (i < lines.Count - 1)
                {
                    sb.Append(foldSeperator);
                }
            }

            return sb.ToString();
        }

        private static string FoldTextToOneLineV2(string multiLineString, int maxLines, string foldSeperator)
        {
            return multiLineString.Split('\n', ',', ';')
                                  .Select(line => line.Trim())
                                  .Where(trimmedLine => trimmedLine.Length > 0)
                                  .Take(maxLines)
                                  .Aggregate((first, second) => first + foldSeperator + second);
        }
        #endregion

        #region Primitive obsession - part 1
        private static void PrimitiveObsessionLessBasic()
        {

        }

        private static void DoSomethingWithCustomerId( CustomerId c)
        {
            Console.WriteLine(c);
        }
        #endregion

        #region Primitive obsession - part 2
        private static void PrimitiveObsessionBasic()
        {
            string testString = "sjfjfmdf";
            var opStr = GetLongString(testString);

        }

        private static Option<string> GetLongString(string str)
        {
            throw new Exception();
        }
        #endregion
    }
}
