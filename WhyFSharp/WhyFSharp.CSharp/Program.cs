using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WhyFSharp.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            var test = new Model.TwoDPointF(1,2);
            var test2 = new TwoDPointC(1, 2);

            //Console.WriteLine(FoldTextToOneLineV1("kalsjdfosdaoijsdlkdsjfkl sdklfjal,sdjkflsadjflkadf,asdfasdf,dfsafd,        ,sdf", 2, ":)"));
            //Console.WriteLine(FoldTextToOneLineV2("kalsjdfosdaoijsdlkdsjfkl sdklfjal,sdjkflsadjflkadf,asdfasdf,dfsafd,        ,sdf", 2, ":)"));

            //Console.WriteLine(test);
            //Console.WriteLine(test2);
            //ComparePoints();
            //PrintAsync();
            Console.ReadLine();
        }


        private static async void PrintAsync()
        {
            CancellationTokenSource cts = new CancellationTokenSource(1000);
            try
            {
                String test = await Async.DelayPrint(5000, "Finished", cts.Token);
                Console.WriteLine(test);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("I've been cancelled!");
            }
        }


        private static void ComparePoints()
        {
            var pointC1 = new TwoDPointC(1, 2);
            var pointC2 = new TwoDPointC(1, 2);
            var pointC3 = new TwoDPointC(1, 3);

            Console.WriteLine(CompareObjects(pointC1, pointC1));
            Console.WriteLine(CompareObjects(pointC1, pointC2));
            Console.WriteLine(CompareObjects(pointC1, pointC3));

            var pointF1 = new Model.TwoDPointF(1, 2);
            var pointF2 = new Model.TwoDPointF(1, 2);
            var pointF3 = new Model.TwoDPointF(1, 3);

            Console.WriteLine(CompareObjects(pointF1, pointF1));
            Console.WriteLine(CompareObjects(pointF1, pointF2));
            Console.WriteLine(CompareObjects(pointF1, pointF3));
        }

        private static string CompareObjects(object first, object second)
        {
            return string.Format("{0} \n{1} \nare equal? {2}", first, second, first.Equals(second));
        }


        public static string FoldTextToOneLineV1(string s, int maxLines, string foldSeperator)
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

        public static string FoldTextToOneLineV2(string multiLineString, int maxLines, string foldSeperator)
        {
            return multiLineString.Split('\n', ',', ';')
                                  .Select(line => line.Trim())
                                  .Where(trimmedLine => trimmedLine.Length > 0)
                                  .Take(maxLines)
                                  .Aggregate((first, second) => first + foldSeperator + second);
        }
    }
}
