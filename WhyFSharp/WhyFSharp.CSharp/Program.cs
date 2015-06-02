using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhyFSharp.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            WhyFSharp.FSharp.Api.List.FoldTextToOneLineV4
        }

        public static string FoldTextToOneLineV1(string s, int maxLines = 8, string foldSeperator = ", ")
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

        public static string FoldTextToOneLineV2(string multiLineString, int maxLines = 8, string foldSeperator = ", ")
        {
            return multiLineString.Split('\n', ',', ';')
                                  .Select(line => line.Trim())
                                  .Where(trimmedLine => trimmedLine.Length > 0)
                                  .Take(maxLines)
                                  .Aggregate((first, second) => first + foldSeperator + second);
        }
    }
}
